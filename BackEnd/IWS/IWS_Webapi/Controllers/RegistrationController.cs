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
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<t_registration> registrationBusiness;      // 业务层对象
            QueryModel model;                                            // Json序列化对象
            List<t_registration> lstRegistration;                        // 用户数据集合
            Dictionary<string, string> dicCondition;                     // 条件集合
            string rtnJson = string.Empty;                               // 返回用Json字符串
            RegistrationConditionModel conditionModel;                   // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new RegistrationConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.CompanyId = requestList.Exists(s => s.Key.ToLower() == "companyId".ToLower()) ? requestList.First(s => s.Key.ToLower() == "companyId".ToLower()).Value : "";
            conditionModel.CompanyName = requestList.Exists(s => s.Key.ToLower() == "companyName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "companyName".ToLower()).Value : "";
            conditionModel.UserId = requestList.Exists(s => s.Key.ToLower() == "userId".ToLower()) ? requestList.First(s => s.Key.ToLower() == "userId".ToLower()).Value : "";
            conditionModel.UserName = requestList.Exists(s => s.Key.ToLower() == "userName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "userName".ToLower()).Value : "";
            conditionModel.VehicleNumber = requestList.Exists(s => s.Key.ToLower() == "vehicleNumber".ToLower()) ? requestList.First(s => s.Key.ToLower() == "vehicleNumber".ToLower()).Value : "";
            conditionModel.EntranceGate = requestList.Exists(s => s.Key.ToLower() == "entranceGate".ToLower()) ? requestList.First(s => s.Key.ToLower() == "entranceGate".ToLower()).Value : "";
            conditionModel.Overseer = requestList.Exists(s => s.Key.ToLower() == "overseer".ToLower()) ? requestList.First(s => s.Key.ToLower() == "overseer".ToLower()).Value : "";
            conditionModel.Reason = requestList.Exists(s => s.Key.ToLower() == "reason".ToLower()) ? requestList.First(s => s.Key.ToLower() == "reason".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

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
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetRegistrationCondition(conditionModel);

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

        /// <summary>
        /// 入场登记数据插入
        /// </summary>
        /// <param name="entity">入场登记数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] t_registration entity)
        {

            InterfaceBusiness<t_registration> registrationBusiness;    // 业务层对象
            QueryModel model;                                          // Json序列化对象
            List<t_registration> lstRegistration;                      // 入场登记数据集合
            int rtnValue = 0;                                          // 执行结果

            try
            {
                // 对象实例化
                registrationBusiness = new RegistrationBusiness();
                lstRegistration = new List<t_registration>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstRegistration.Add(entity);
                rtnValue = registrationBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstRegistration);

                model.State = 1;
                model.Data = lstRegistration;
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
        /// 用户数据删除
        /// </summary>
        /// <param name="Id">用户数据键</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string Id)
        {
            InterfaceBusiness<t_registration> registrationBusiness;    // 业务层对象
            QueryModel model;                                          // Json序列化对象
            Dictionary<string, string> dicCondition;                   // 条件集合
            RegistrationConditionModel conditionModel;                 // 条件模型
            int rtnValue = 0;                                          // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new RegistrationConditionModel();
                registrationBusiness = new RegistrationBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.OprationKind = AppConst.Operation_Delete;
                conditionModel.Id = Id;
                dicCondition = AppCommon.GetRegistrationCondition(conditionModel);
                rtnValue = registrationBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

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
        /// 入场登记数据更新
        /// </summary>
        /// <param name="entity">入场登记数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] t_registration entity)
        {
            InterfaceBusiness<t_registration> registrationBusiness;   // 业务层对象
            QueryModel model;                                         // Json序列化对象
            List<t_registration> lstRegistration;                     // 用户数据集合
            int rtnValue = 0;                                         // 执行结果

            try
            {
                // 对象实例化
                registrationBusiness = new RegistrationBusiness();
                lstRegistration = new List<t_registration>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstRegistration.Add(entity);
                rtnValue = registrationBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstRegistration);

                model.State = 1;
                model.Data = lstRegistration;
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
