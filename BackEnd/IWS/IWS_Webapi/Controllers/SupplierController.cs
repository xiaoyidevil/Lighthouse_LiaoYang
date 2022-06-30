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
    /// 供应商Controller
    /// </summary>
    public class SupplierController : ApiController
    {
        /// <summary>
        /// 供应商数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<m_supplier> supplierBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_supplier> lstSupplier;                          // 用户数据集合
            Dictionary<string, string> dicCondition;               // 条件集合
            string rtnJson = string.Empty;                         // 返回用Json字符串
            SupplierConditionModel conditionModel;                 // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new SupplierConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.SupplierId = requestList.Exists(s => s.Key.ToLower() == "supplierId".ToLower()) ? requestList.First(s => s.Key.ToLower() == "supplierId".ToLower()).Value : "";
            conditionModel.CompanyName = requestList.Exists(s => s.Key.ToLower() == "companyName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "companyName".ToLower()).Value : "";
            conditionModel.CompanyAddress = requestList.Exists(s => s.Key.ToLower() == "companyAddress".ToLower()) ? requestList.First(s => s.Key.ToLower() == "companyAddress".ToLower()).Value : "";
            conditionModel.PostCode1 = requestList.Exists(s => s.Key.ToLower() == "postCode1".ToLower()) ? requestList.First(s => s.Key.ToLower() == "postCode1".ToLower()).Value : "";
            conditionModel.PostCode2 = requestList.Exists(s => s.Key.ToLower() == "postCode2".ToLower()) ? requestList.First(s => s.Key.ToLower() == "postCode2".ToLower()).Value : "";
            conditionModel.Website = requestList.Exists(s => s.Key.ToLower() == "website".ToLower()) ? requestList.First(s => s.Key.ToLower() == "website".ToLower()).Value : "";
            conditionModel.NatureEnterprise = requestList.Exists(s => s.Key.ToLower() == "natureEnterprise".ToLower()) ? requestList.First(s => s.Key.ToLower() == "natureEnterprise".ToLower()).Value : "";
            conditionModel.Tel = requestList.Exists(s => s.Key.ToLower() == "tel".ToLower()) ? requestList.First(s => s.Key.ToLower() == "tel".ToLower()).Value : "";
            conditionModel.Fax = requestList.Exists(s => s.Key.ToLower() == "fax".ToLower()) ? requestList.First(s => s.Key.ToLower() == "fax".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

            try
            {
                // 对象实例化
                supplierBusiness = new SupplierBusiness();
                model = new QueryModel();
                lstSupplier = new List<m_supplier>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetSupplierCondition(conditionModel);

                // Json数据序列化
                lstSupplier = supplierBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstSupplier;
                model.TotalDataCount = supplierBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
        /// 供应商数据插入
        /// </summary>
        /// <param name="entity">供应商数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] m_supplier entity)
        {

            InterfaceBusiness<m_supplier> supplierBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_supplier> lstSupplier;                          // 供应商数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                supplierBusiness = new SupplierBusiness();
                lstSupplier = new List<m_supplier>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstSupplier.Add(entity);
                rtnValue = supplierBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstSupplier);

                model.State = 1;
                model.Data = lstSupplier;
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
        /// 供应商数据删除
        /// </summary>
        /// <param name="Id">供应商数据键</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string Id)
        {
            InterfaceBusiness<m_supplier> supplierBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            Dictionary<string, string> dicCondition;               // 条件集合
            SupplierConditionModel conditionModel;                 // 条件模型
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new SupplierConditionModel();
                supplierBusiness = new SupplierBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.OprationKind = AppConst.Operation_Delete;
                conditionModel.Id = Id;
                dicCondition = AppCommon.GetSupplierCondition(conditionModel);
                rtnValue = supplierBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

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
        /// 供应商数据更新
        /// </summary>
        /// <param name="entity">供应商数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] m_supplier entity)
        {
            InterfaceBusiness<m_supplier> supplierBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_supplier> lstSupplier;                          // 供应商数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                supplierBusiness = new SupplierBusiness();
                lstSupplier = new List<m_supplier>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstSupplier.Add(entity);
                rtnValue = supplierBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstSupplier);

                model.State = 1;
                model.Data = lstSupplier;
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
