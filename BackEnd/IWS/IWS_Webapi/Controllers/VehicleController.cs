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
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<m_vehicle> vehicleusiness;              // 业务层对象
            QueryModel model;                                         // Json序列化对象
            List<m_vehicle> lstVehicle;                               // 车辆数据集合
            Dictionary<string, string> dicCondition;                  // 条件集合
            string rtnJson = string.Empty;                            // 返回用Json字符串
            VehicleConditionModel conditionModel;                     // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new VehicleConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.VehicleNumber = requestList.Exists(s => s.Key.ToLower() == "vehicleNumber".ToLower()) ? requestList.First(s => s.Key.ToLower() == "vehicleNumber".ToLower()).Value : "";
            conditionModel.CompanyName = requestList.Exists(s => s.Key.ToLower() == "companyName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "companyName".ToLower()).Value : "";
            conditionModel.BrandModel = requestList.Exists(s => s.Key.ToLower() == "brandModel".ToLower()) ? requestList.First(s => s.Key.ToLower() == "brandModel".ToLower()).Value : "";
            conditionModel.Color = requestList.Exists(s => s.Key.ToLower() == "color".ToLower()) ? requestList.First(s => s.Key.ToLower() == "color".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

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
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetVehicleCondition(conditionModel);

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

        /// <summary>
        /// 车辆数据插入
        /// </summary>
        /// <param name="entity">用户数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] m_vehicle entity)
        {
            InterfaceBusiness<m_vehicle> userBusiness;             // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_vehicle> lstVehicle;                            // 车辆数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                userBusiness = new VehicleBusiness();
                lstVehicle = new List<m_vehicle>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstVehicle.Add(entity);
                rtnValue = userBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstVehicle);

                model.State = 1;
                model.Data = lstVehicle;
                model.Msg = rtnValue > 0 ? AppConst.Excute_Success : AppConst.Excute_NoData;
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

        /// <summary>
        /// 车辆数据删除
        /// </summary>
        /// <param name="Id">车辆数据键</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string Id)
        {
            InterfaceBusiness<m_vehicle> vehicleBusiness;          // 业务层对象
            QueryModel model;                                      // Json序列化对象
            Dictionary<string, string> dicCondition;               // 条件集合
            VehicleConditionModel conditionModel;                  // 条件模型
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new VehicleConditionModel();
                vehicleBusiness = new VehicleBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.Id = Id;
                conditionModel.OprationKind = AppConst.Operation_Delete;
                dicCondition = AppCommon.GetVehicleCondition(conditionModel);
                rtnValue = vehicleBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

                model.State = 1;
                model.Msg = rtnValue > 0 ? AppConst.Excute_Success : AppConst.Excute_NoData;
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

        /// <summary>
        /// 车辆数据更新
        /// </summary>
        /// <param name="entity">车辆数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] m_vehicle entity)
        {
            InterfaceBusiness<m_vehicle> vehicleBusiness;          // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_vehicle> lstVehicle;                            // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                vehicleBusiness = new VehicleBusiness();
                lstVehicle = new List<m_vehicle>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstVehicle.Add(entity);
                rtnValue = vehicleBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstVehicle);

                model.State = 1;
                model.Data = lstVehicle;
                model.Msg = rtnValue > 0 ? AppConst.Excute_Success : AppConst.Excute_NoData;
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
