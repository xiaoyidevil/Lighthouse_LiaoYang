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
    /// 需求方Controller
    /// </summary>
    public class DemanderController : ApiController
    {
        /// <summary>
        /// 需求方数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetUserData()
        {
            InterfaceBusiness<m_user> userBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_user> lstUser;                                  // 用户数据集合
            Dictionary<string, string> dicCondition;               // 条件集合
            string rtnJson = string.Empty;                         // 返回用Json字符串
            int startIndex = 0;                                    // 数据条数开始索引

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;
            string userId;
            string userName;
            string telephone;
            string idCard;
            string age;
            string sex;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();

            strCurrentPage = requestList.Exists(s => s.Key == "currentPage") ? requestList.First(s => s.Key == "currentPage").Value : "";
            strPageCnt = requestList.Exists(s => s.Key == "pageCnt") ? requestList.First(s => s.Key == "pageCnt").Value : "";
            userId = requestList.Exists(s => s.Key == "userId") ? requestList.First(s => s.Key == "userId").Value : "";
            userName = requestList.Exists(s => s.Key == "userName") ? requestList.First(s => s.Key == "userName").Value : "";
            telephone = requestList.Exists(s => s.Key == "telephone") ? requestList.First(s => s.Key == "telephone").Value : "";
            idCard = requestList.Exists(s => s.Key == "idCard") ? requestList.First(s => s.Key == "idCard").Value : "";
            age = requestList.Exists(s => s.Key == "age") ? requestList.First(s => s.Key == "age").Value : "";
            sex = requestList.Exists(s => s.Key == "sex") ? requestList.First(s => s.Key == "sex").Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;

            try
            {
                // 对象实例化
                userBusiness = new UserBusiness();
                model = new QueryModel();
                lstUser = new List<m_user>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                startIndex = (currentPage - 1) * pageCnt;
                //dicCondition = AppCommon.GetUserCondition(startIndex, pageCnt, userId, userName, telephone, idCard, age, sex);

                // Json数据序列化
                lstUser = userBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstUser;
                model.TotalDataCount = userBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
