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
    /// 物料Controller
    /// </summary>
    public class MaterialController : ApiController
    {
        /// <summary>
        /// 物料数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<m_material> materialBusiness;            // 业务层对象
            QueryModel model;                                          // Json序列化对象
            List<m_material> lstMaterial;                              // 物料数据集合
            Dictionary<string, string> dicCondition;                   // 条件集合
            string rtnJson = string.Empty;                             // 返回用Json字符串
            MaterialConditionModel conditionModel;                     // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new MaterialConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.MaterialId = requestList.Exists(s => s.Key.ToLower() == "materialId".ToLower()) ? requestList.First(s => s.Key.ToLower() == "materialId".ToLower()).Value : "";
            conditionModel.MaterialName = requestList.Exists(s => s.Key.ToLower() == "materialName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "materialName".ToLower()).Value : "";
            conditionModel.MaterialEnglishName = requestList.Exists(s => s.Key.ToLower() == "materialEnglishName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "materialEnglishName".ToLower()).Value : "";
            conditionModel.SpecificationsModel = requestList.Exists(s => s.Key.ToLower() == "specificationsModel".ToLower()) ? requestList.First(s => s.Key.ToLower() == "specificationsModel".ToLower()).Value : "";
            conditionModel.Material = requestList.Exists(s => s.Key.ToLower() == "material".ToLower()) ? requestList.First(s => s.Key.ToLower() == "material".ToLower()).Value : "";
            conditionModel.MaterialKind = requestList.Exists(s => s.Key.ToLower() == "materialKind".ToLower()) ? requestList.First(s => s.Key.ToLower() == "materialKind".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

            try
            {
                // 对象实例化
                materialBusiness = new MaterialBusiness();
                model = new QueryModel();
                lstMaterial = new List<m_material>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetMaterialCondition(conditionModel);

                // Json数据序列化
                lstMaterial = materialBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstMaterial;
                model.TotalDataCount = materialBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
        /// 物料数据插入
        /// </summary>
        /// <param name="entity">物料数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] m_material entity)
        {

            InterfaceBusiness<m_material> materialBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_material> lstMaterial;                          // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                materialBusiness = new MaterialBusiness();
                lstMaterial = new List<m_material>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstMaterial.Add(entity);
                rtnValue = materialBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstMaterial);

                model.State = 1;
                model.Data = lstMaterial;
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
        /// 物料数据删除
        /// </summary>
        /// <param name="Id">物料数据键</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string Id)
        {
            InterfaceBusiness<m_material> materialBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            Dictionary<string, string> dicCondition;               // 条件集合
            MaterialConditionModel conditionModel;                 // 条件模型
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new MaterialConditionModel();
                materialBusiness = new MaterialBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.OprationKind = AppConst.Operation_Delete;
                conditionModel.Id = Id;
                dicCondition = AppCommon.GetMaterialCondition(conditionModel);
                rtnValue = materialBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

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
        /// 物料数据更新
        /// </summary>
        /// <param name="entity">物料数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] m_material entity)
        {
            InterfaceBusiness<m_material> materialBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_material> lstMaterial;                          // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                materialBusiness = new MaterialBusiness();
                lstMaterial = new List<m_material>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstMaterial.Add(entity);
                rtnValue = materialBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstMaterial);

                model.State = 1;
                model.Data = lstMaterial;
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
