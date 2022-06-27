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
    /// 权限Controller
    /// </summary>
    public class JurisdictionController : ApiController
    {
        /// <summary>
        /// 权限数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GET()
        {
            InterfaceBusiness<m_jurisdiction> jurisdictionBusiness;                // 业务层对象
            QueryModel model;                                                      // Json序列化对象
            List<m_jurisdiction> lstJurisdiction;                                  // 用户数据集合
            Dictionary<string, string> dicCondition;                               // 条件集合
            string rtnJson = string.Empty;                                         // 返回用Json字符串
            int startIndex = 0;                                                    // 数据条数开始索引

            int roleId = 0;
            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strRoleId;
            string strPageCnt;
            string jurisdictionId;
            string jurisdictionLevel;
            string jurisdictionName;
            string jurisdictionPath;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();

            strRoleId = requestList.Exists(s => s.Key.ToLower() == "roleid") ? requestList.First(s => s.Key.ToLower() == "roleid").Value : "";
            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentpage") ? requestList.First(s => s.Key.ToLower() == "currentpage").Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pagecnt") ? requestList.First(s => s.Key.ToLower() == "pagecnt").Value : "";
            jurisdictionId = requestList.Exists(s => s.Key.ToLower() == "jurisdictionid") ? requestList.First(s => s.Key.ToLower() == "jurisdictionid").Value : "";
            jurisdictionLevel = requestList.Exists(s => s.Key.ToLower() == "jurisdictionlevel") ? requestList.First(s => s.Key.ToLower() == "jurisdictionlevel").Value : "";
            jurisdictionName = requestList.Exists(s => s.Key.ToLower() == "jurisdictionname") ? requestList.First(s => s.Key.ToLower() == "jurisdictionname").Value : "";
            jurisdictionPath = requestList.Exists(s => s.Key.ToLower() == "jurisdictionpath") ? requestList.First(s => s.Key.ToLower() == "jurisdictionpath").Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            int.TryParse(strRoleId, out roleId);

            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;

            try
            {
                // 对象实例化
                jurisdictionBusiness = new JurisdictionBusiness();
                model = new QueryModel();
                lstJurisdiction = new List<m_jurisdiction>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                startIndex = (currentPage - 1) * pageCnt;
                //dicCondition = AppCommon.GetJurisdictionCondition(startIndex, pageCnt, jurisdictionId, jurisdictionLevel, jurisdictionName, jurisdictionPath);
                dicCondition = AppCommon.GetJurisdictionCondition(roleId);

                // Json数据序列化
                lstJurisdiction = jurisdictionBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstJurisdiction;
                List<m_jurisdiction_Cascading> lst_m_Jurisdiction_Cascading = GetJurisdiction_Cascading(lstJurisdiction);
                model.Data = lst_m_Jurisdiction_Cascading;
                model.TotalDataCount = jurisdictionBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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

        protected List<m_jurisdiction_Cascading> GetJurisdiction_Cascading(List<m_jurisdiction> lst_m_jurisdiction) {
            List<m_jurisdiction_Cascading> lst_m_Jurisdiction_Cascading = new List<m_jurisdiction_Cascading>();

            //foreach (var item in (from u in lst_m_jurisdiction orderby u.JurisdictionLevel descending select (u.JurisdictionLevel)).Distinct() ) //获取权限层级：JurisdictionLevel
            //foreach (var item in lst_m_jurisdiction.Select(p => p.JurisdictionLevel).ToList().Distinct()) //获取权限层级：JurisdictionLevel

            foreach (m_jurisdiction var_m_jurisdiction in lst_m_jurisdiction.FindAll(p => p.JurisdictionLevel == 1)) //根据权限层级生成新的权限list
            {
                m_jurisdiction_Cascading tmp_m_jurisdiction_Cascading = new m_jurisdiction_Cascading();
                tmp_m_jurisdiction_Cascading.JurisdictionId = var_m_jurisdiction.JurisdictionId;
                tmp_m_jurisdiction_Cascading.JurisdictionLevel = var_m_jurisdiction.JurisdictionLevel;
                tmp_m_jurisdiction_Cascading.ParentID = var_m_jurisdiction.ParentID;
                tmp_m_jurisdiction_Cascading.JurisdictionName = var_m_jurisdiction.JurisdictionName;
                tmp_m_jurisdiction_Cascading.JurisdictionPath = var_m_jurisdiction.JurisdictionPath;

                tmp_m_jurisdiction_Cascading.SubJurisdiction = lst_m_jurisdiction.FindAll(p => p.JurisdictionLevel == 2 && p.ParentID == var_m_jurisdiction.JurisdictionId);

                lst_m_Jurisdiction_Cascading.Add(tmp_m_jurisdiction_Cascading);
            }

            return lst_m_Jurisdiction_Cascading;
        }

    }
}
