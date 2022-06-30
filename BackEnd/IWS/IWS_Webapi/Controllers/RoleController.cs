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
    /// 角色Controller
    /// </summary>
    public class RoleController : ApiController
    {
        /// <summary>
        /// 角色数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<m_role> roleBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_role> lstRole;                                  // 角色数据集合
            Dictionary<string, string> dicCondition;               // 条件集合
            string rtnJson = string.Empty;                         // 返回用Json字符串
            RoleConditionModel conditionModel;                     // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new RoleConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.RoleId = requestList.Exists(s => s.Key.ToLower() == "roleId".ToLower()) ? requestList.First(s => s.Key.ToLower() == "roleId".ToLower()).Value : "";
            conditionModel.RoleName = requestList.Exists(s => s.Key.ToLower() == "roleName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "roleName".ToLower()).Value : "";
            conditionModel.RoleDesc = requestList.Exists(s => s.Key.ToLower() == "RoleDesc".ToLower()) ? requestList.First(s => s.Key.ToLower() == "RoleDesc".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

            try
            {
                // 对象实例化
                roleBusiness = new RoleBusiness();
                model = new QueryModel();
                lstRole = new List<m_role>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetRoleCondition(conditionModel);

                // Json数据序列化
                lstRole = roleBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstRole;
                model.TotalDataCount = roleBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
        /// 角色数据插入
        /// </summary>
        /// <param name="entity">角色数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] m_role entity)
        {

            InterfaceBusiness<m_role> roleBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_role> lstRole;                                  // 角色数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                roleBusiness = new RoleBusiness();
                lstRole = new List<m_role>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstRole.Add(entity);
                rtnValue = roleBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstRole);

                model.State = 1;
                model.Data = lstRole;
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
        /// 角色数据删除
        /// </summary>
        /// <param name="Id">角色数据键</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string Id)
        {
            InterfaceBusiness<m_role> roleBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            Dictionary<string, string> dicCondition;               // 条件集合
            RoleConditionModel conditionModel;                     // 条件模型
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new RoleConditionModel();
                roleBusiness = new RoleBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.OprationKind = AppConst.Operation_Delete;
                conditionModel.RoleId = Id;
                dicCondition = AppCommon.GetRoleCondition(conditionModel);
                rtnValue = roleBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

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
        /// 角色数据更新
        /// </summary>
        /// <param name="entity">角色数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] m_role entity)
        {

            InterfaceBusiness<m_role> roleBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_role> lstRole;                                  // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                roleBusiness = new RoleBusiness();
                lstRole = new List<m_role>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstRole.Add(entity);
                rtnValue = roleBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstRole);

                model.State = 1;
                model.Data = lstRole;
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
