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
    /// 审批Controller
    /// </summary>
    public class ApprovalController : ApiController
    {
        /// <summary>
        /// 审批数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<t_approval> approvalBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<t_approval> lstApproval;                          // 入场审批数据集合
            Dictionary<string, string> dicCondition;               // 条件集合
            string rtnJson = string.Empty;                         // 返回用Json字符串
            ApprovalConditionModel conditionModel;                 // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new ApprovalConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.AdmisionType = requestList.Exists(s => s.Key.ToLower() == "AdmisionType".ToLower()) ? requestList.First(s => s.Key.ToLower() == "AdmisionType".ToLower()).Value : "";
            conditionModel.CompanyName = requestList.Exists(s => s.Key.ToLower() == "CompanyName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "CompanyName".ToLower()).Value : "";
            conditionModel.UserName = requestList.Exists(s => s.Key.ToLower() == "UserName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "UserName".ToLower()).Value : "";
            conditionModel.VehicleNumber = requestList.Exists(s => s.Key.ToLower() == "VehicleNumber".ToLower()) ? requestList.First(s => s.Key.ToLower() == "VehicleNumber".ToLower()).Value : "";
            conditionModel.EntranceGate = requestList.Exists(s => s.Key.ToLower() == "EntranceGate".ToLower()) ? requestList.First(s => s.Key.ToLower() == "EntranceGate".ToLower()).Value : "";
            conditionModel.Accption = requestList.Exists(s => s.Key.ToLower() == "Accption".ToLower()) ? requestList.First(s => s.Key.ToLower() == "Accption".ToLower()).Value : "";
            conditionModel.ApprovalState = requestList.Exists(s => s.Key.ToLower() == "ApprovalState".ToLower()) ? requestList.First(s => s.Key.ToLower() == "ApprovalState".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

            try
            {
                // 对象实例化
                approvalBusiness = new ApprovalBusiness();
                model = new QueryModel();
                lstApproval = new List<t_approval>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetApprovalCondition(conditionModel);

                // Json数据序列化
                lstApproval = approvalBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstApproval;
                model.TotalDataCount = approvalBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
        /// 入场审批数据插入
        /// </summary>
        /// <param name="entity">入场审批数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] t_approval entity)
        {

            InterfaceBusiness<t_approval> approvalBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<t_approval> lstApproval;                          // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                approvalBusiness = new ApprovalBusiness();
                lstApproval = new List<t_approval>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstApproval.Add(entity);
                rtnValue = approvalBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstApproval);

                model.State = 1;
                model.Data = lstApproval;
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
        /// 入场审批数据删除
        /// </summary>
        /// <param name="Id">用户数据键</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string Id)
        {
            InterfaceBusiness<t_approval> approvalBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            Dictionary<string, string> dicCondition;               // 条件集合
            ApprovalConditionModel conditionModel;                 // 条件模型
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new ApprovalConditionModel();
                approvalBusiness = new ApprovalBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.OprationKind = AppConst.Operation_Delete;
                conditionModel.Id = Id;
                dicCondition = AppCommon.GetApprovalCondition(conditionModel);
                rtnValue = approvalBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

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
        /// 入场审批数据更新
        /// </summary>
        /// <param name="entity">入场审批数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] t_approval entity)
        {
            InterfaceBusiness<t_approval> approvalBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<t_approval> lstApproval;                          // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                approvalBusiness = new ApprovalBusiness();
                lstApproval = new List<t_approval>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstApproval.Add(entity);
                rtnValue = approvalBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstApproval);

                model.State = 1;
                model.Data = lstApproval;
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
