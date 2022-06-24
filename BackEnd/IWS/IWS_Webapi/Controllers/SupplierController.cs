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
        /// 用户数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetSupplierData()
        {
            InterfaceBusiness<m_supplier> supplierBusiness;        // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_supplier> lstSupplier;                          // 用户数据集合
            Dictionary<string, string> dicCondition;               // 条件集合
            string rtnJson = string.Empty;                         // 返回用Json字符串
            int startIndex = 0;                                    // 数据条数开始索引

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;
            string supplierId;
            string companyName;
            string companyAddress;
            string postCode1;
            string postCode2;
            string website;
            string natureEnterprise;
            string tel;
            string fax;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();

            strCurrentPage = requestList.Exists(s => s.Key == "currentPage") ? requestList.First(s => s.Key == "currentPage").Value : "";
            strPageCnt = requestList.Exists(s => s.Key == "pageCnt") ? requestList.First(s => s.Key == "pageCnt").Value : "";
            supplierId = requestList.Exists(s => s.Key == "supplierId") ? requestList.First(s => s.Key == "supplierId").Value : "";
            companyName = requestList.Exists(s => s.Key == "companyName") ? requestList.First(s => s.Key == "companyName").Value : "";
            companyAddress = requestList.Exists(s => s.Key == "companyAddress") ? requestList.First(s => s.Key == "companyAddress").Value : "";
            postCode1 = requestList.Exists(s => s.Key == "postCode1") ? requestList.First(s => s.Key == "postCode1").Value : "";
            postCode2 = requestList.Exists(s => s.Key == "postCode2") ? requestList.First(s => s.Key == "postCode2").Value : "";
            website = requestList.Exists(s => s.Key == "website") ? requestList.First(s => s.Key == "website").Value : "";
            natureEnterprise = requestList.Exists(s => s.Key == "natureEnterprise") ? requestList.First(s => s.Key == "natureEnterprise").Value : "";
            tel = requestList.Exists(s => s.Key == "tel") ? requestList.First(s => s.Key == "tel").Value : "";
            fax = requestList.Exists(s => s.Key == "fax") ? requestList.First(s => s.Key == "fax").Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;

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
                startIndex = (currentPage - 1) * pageCnt;
                dicCondition = AppCommon.GetSupplierCondition(startIndex, pageCnt, supplierId, companyName, companyAddress, postCode1, postCode2, website, natureEnterprise, tel, fax);

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
    }
}
