using IWS_Business.Business;
using IWS_Business.BusinessIF;
using IWS_Common.Const;
using IWS_Common.Model;
using IWS_Common.Mysql;
using IWS_Common.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IWS_Webapi.Controllers
{
    /// <summary>
    /// 入场登记Controller
    /// </summary>
    public class RegistrationController : ApiController
    {
        /// <summary>
        /// 入场登记数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetSupplierData()
        {
            InterfaceBusiness<t_registration> registrationBusiness;      // 业务层对象
            QueryModel model;                                            // Json序列化对象
            List<t_registration> lstRegistration;                        // 用户数据集合
            Dictionary<string, string> dicCondition;                     // 条件集合
            string rtnJson = string.Empty;                               // 返回用Json字符串
            int startIndex = 0;                                          // 数据条数开始索引

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;
            string companyId;
            string companyName;
            string userId;
            string userName;
            string vehicleNumber;
            string entranceGate;
            string entranceDateTimeFrom;
            string entranceDateTimeTo;
            string overseer;
            string reason;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();

            strCurrentPage = requestList.Exists(s => s.Key == "currentPage") ? requestList.First(s => s.Key == "currentPage").Value : "";
            strPageCnt = requestList.Exists(s => s.Key == "pageCnt") ? requestList.First(s => s.Key == "pageCnt").Value : "";
            companyId = requestList.Exists(s => s.Key == "companyId") ? requestList.First(s => s.Key == "companyId").Value : "";
            companyName = requestList.Exists(s => s.Key == "companyName") ? requestList.First(s => s.Key == "companyName").Value : "";
            userId = requestList.Exists(s => s.Key == "userId") ? requestList.First(s => s.Key == "userId").Value : "";
            userName = requestList.Exists(s => s.Key == "userName") ? requestList.First(s => s.Key == "userName").Value : "";
            vehicleNumber = requestList.Exists(s => s.Key == "vehicleNumber") ? requestList.First(s => s.Key == "vehicleNumber").Value : "";
            entranceGate = requestList.Exists(s => s.Key == "entranceGate") ? requestList.First(s => s.Key == "entranceGate").Value : "";
            entranceDateTimeFrom = requestList.Exists(s => s.Key == "entranceDateTimeFrom") ? requestList.First(s => s.Key == "entranceDateTimeFrom").Value : "";
            entranceDateTimeTo = requestList.Exists(s => s.Key == "entranceDateTimeTo") ? requestList.First(s => s.Key == "entranceDateTimeTo").Value : "";
            overseer = requestList.Exists(s => s.Key == "overseer") ? requestList.First(s => s.Key == "overseer").Value : "";
            reason = requestList.Exists(s => s.Key == "reason") ? requestList.First(s => s.Key == "reason").Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;

            try
            {
                // 对象实例化
                registrationBusiness = new RegistrationBusiness();
                model = new QueryModel();
                lstRegistration = new List<t_registration>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                startIndex = (currentPage - 1) * pageCnt;
                dicCondition = AppCommon.GetRegistrationCondition(startIndex, pageCnt, companyId, companyName, userId, userName, vehicleNumber, entranceGate, entranceDateTimeFrom, entranceDateTimeTo, overseer, reason);

                // Json数据序列化
                lstRegistration = registrationBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstRegistration;
                model.TotalDataCount = registrationBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
                model.CurrentPage = currentPage;
                model.TotalPageCnt = AppCommon.GetTotalPageCnt(pageCnt, model.TotalDataCount);
                model.State = 1;
                model.Msg = AppConst.Excute_Success;
            }
            catch (Exception ex)
            {
                model = new QueryModel();
                model.State = 7;
                model.Msg = ex.Message.ToString();
            }

            // Json序列化返回
            string json = JsonConvert.SerializeObject(model);
            return new HttpResponseMessage
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
