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
    public class VehicleController : ApiController
    {
        /// <summary>
        /// 车辆数据查询
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="vehicleNumber">车牌号</param>
        /// <param name="companyName">所属公司名称</param>
        /// <param name="brandModel">品牌型号</param>
        /// <param name="color">车身颜色</param>
        /// <returns></returns>
        public HttpResponseMessage GetVehicleData()
        {
            InterfaceBusiness<m_vehicle> vehicleusiness;              // 业务层对象
            QueryModel model;                                         // Json序列化对象
            List<m_vehicle> lstVehicle;                               // 车辆数据集合
            Dictionary<string, string> dicCondition;                  // 条件集合
            string rtnJson = string.Empty;                            // 返回用Json字符串
            int startIndex = 0;                                       // 数据条数开始索引

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;
            string vehicleNumber;
            string companyName;
            string brandModel;
            string color;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();

            strCurrentPage = requestList.Exists(s => s.Key == "currentPage") ? requestList.First(s => s.Key == "currentPage").Value : "";
            strPageCnt = requestList.Exists(s => s.Key == "pageCnt") ? requestList.First(s => s.Key == "pageCnt").Value : "";
            vehicleNumber = requestList.Exists(s => s.Key == "vehicleNumber") ? requestList.First(s => s.Key == "vehicleNumber").Value : "";
            companyName = requestList.Exists(s => s.Key == "companyName") ? requestList.First(s => s.Key == "companyName").Value : "";
            brandModel = requestList.Exists(s => s.Key == "brandModel") ? requestList.First(s => s.Key == "brandModel").Value : "";
            color = requestList.Exists(s => s.Key == "color") ? requestList.First(s => s.Key == "color").Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;

            try
            {
                // 对象实例化
                vehicleusiness = new VehicleBusiness();
                model = new QueryModel();
                lstVehicle = new List<m_vehicle>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                startIndex = (currentPage - 1) * pageCnt;
                dicCondition = AppCommon.GetVehicleCondition(startIndex, pageCnt, vehicleNumber, companyName, brandModel, color);

                // Json数据序列化
                lstVehicle = vehicleusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstVehicle;
                model.TotalDataCount = vehicleusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
