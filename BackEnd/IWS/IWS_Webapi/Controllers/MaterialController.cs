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
        /// 用户数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetUserData()
        {
            InterfaceBusiness<m_material> materialBusiness;            // 业务层对象
            QueryModel model;                                          // Json序列化对象
            List<m_material> lstUser;                                  // 用户数据集合
            Dictionary<string, string> dicCondition;                   // 条件集合
            string rtnJson = string.Empty;                             // 返回用Json字符串
            int startIndex = 0;                                        // 数据条数开始索引

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;
            string materialId;
            string materialName;
            string materialEnglishName;
            string specificationsModel;
            string material;
            string materialKind;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();

            strCurrentPage = requestList.Exists(s => s.Key == "currentPage") ? requestList.First(s => s.Key == "currentPage").Value : "";
            strPageCnt = requestList.Exists(s => s.Key == "pageCnt") ? requestList.First(s => s.Key == "pageCnt").Value : "";
            materialId = requestList.Exists(s => s.Key == "materialId") ? requestList.First(s => s.Key == "materialId").Value : "";
            materialName = requestList.Exists(s => s.Key == "materialName") ? requestList.First(s => s.Key == "materialName").Value : "";
            materialEnglishName = requestList.Exists(s => s.Key == "materialEnglishName") ? requestList.First(s => s.Key == "materialEnglishName").Value : "";
            specificationsModel = requestList.Exists(s => s.Key == "specificationsModel") ? requestList.First(s => s.Key == "specificationsModel").Value : "";
            material = requestList.Exists(s => s.Key == "material") ? requestList.First(s => s.Key == "material").Value : "";
            materialKind = requestList.Exists(s => s.Key == "materialKind") ? requestList.First(s => s.Key == "materialKind").Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;

            try
            {
                // 对象实例化
                materialBusiness = new MaterialBusiness();
                model = new QueryModel();
                lstUser = new List<m_material>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                startIndex = (currentPage - 1) * pageCnt;
                //dicCondition = AppCommon.GetUserCondition(startIndex, pageCnt, materialId, materialName, materialEnglishName, specificationsModel, material, materialKind);

                // Json数据序列化
                lstUser = materialBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstUser;
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
    }
}
