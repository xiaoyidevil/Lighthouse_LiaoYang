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
using System.Threading.Tasks;
using System.IO;

namespace IWS_Webapi.Controllers
{
    /// <summary>
    /// 用户Controller
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户数据查询
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            InterfaceBusiness<m_user> userBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_user> lstUser;                                  // 用户数据集合
            Dictionary<string, string> dicCondition;               // 条件集合
            string rtnJson = string.Empty;                         // 返回用Json字符串
            UserConditionModel conditionModel;                     // 条件模型

            int currentPage = 0;
            int pageCnt = 1;
            string strCurrentPage;
            string strPageCnt;

            List<KeyValuePair<string, string>> requestList = Request.GetQueryNameValuePairs().ToList();
            conditionModel = new UserConditionModel();

            strCurrentPage = requestList.Exists(s => s.Key.ToLower() == "currentPage".ToLower()) ? requestList.First(s => s.Key.ToLower() == "currentPage".ToLower()).Value : "";
            strPageCnt = requestList.Exists(s => s.Key.ToLower() == "pageCnt".ToLower()) ? requestList.First(s => s.Key.ToLower() == "pageCnt".ToLower()).Value : "";
            conditionModel.UserId = requestList.Exists(s => s.Key.ToLower() == "userId".ToLower()) ? requestList.First(s => s.Key.ToLower() == "userId".ToLower()).Value : "";
            conditionModel.UserName = requestList.Exists(s => s.Key.ToLower() == "userName".ToLower()) ? requestList.First(s => s.Key.ToLower() == "userName".ToLower()).Value : "";
            conditionModel.Telephone = requestList.Exists(s => s.Key.ToLower() == "telephone".ToLower()) ? requestList.First(s => s.Key.ToLower() == "telephone".ToLower()).Value : "";
            conditionModel.IdCard = requestList.Exists(s => s.Key.ToLower() == "idCard".ToLower()) ? requestList.First(s => s.Key.ToLower() == "idCard".ToLower()).Value : "";
            conditionModel.Age = requestList.Exists(s => s.Key.ToLower() == "age".ToLower()) ? requestList.First(s => s.Key.ToLower() == "age".ToLower()).Value : "";
            conditionModel.Sex = requestList.Exists(s => s.Key.ToLower() == "sex".ToLower()) ? requestList.First(s => s.Key.ToLower() == "sex".ToLower()).Value : "";

            int.TryParse(strCurrentPage, out currentPage);
            int.TryParse(strPageCnt, out pageCnt);
            currentPage = currentPage == 0 ? 1 : currentPage;
            pageCnt = pageCnt == 0 ? 10 : pageCnt;
            conditionModel.PageCnt = pageCnt;

            try
            {
                // 对象实例化
                userBusiness = new UserBusiness();
                model = new QueryModel();
                lstUser = new List<m_user>();
                dicCondition = new Dictionary<string, string>();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 条件编辑
                conditionModel.StartIndex = (currentPage - 1) * pageCnt;
                conditionModel.OprationKind = AppConst.Operation_Query;
                dicCondition = AppCommon.GetUserCondition(conditionModel);

                // Json数据序列化
                lstUser = userBusiness.SelectData(DbHelper.GetMysqlConnection(), dicCondition).ToList();
                model.Data = lstUser;
                model.TotalDataCount = userBusiness.SelectDataCnt(DbHelper.GetMysqlConnection(), dicCondition);
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
        /// 用户数据插入
        /// </summary>
        /// <param name="entity">用户数据</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] m_user entity){

            InterfaceBusiness<m_user> userBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_user> lstUser;                                  // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                userBusiness = new UserBusiness();
                lstUser = new List<m_user>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstUser.Add(entity);
                rtnValue = userBusiness.InsertData(DbHelper.GetMysqlConnection(), null, lstUser);

                model.State = 1;
                model.Data = lstUser;
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
            InterfaceBusiness<m_user> userBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            Dictionary<string, string> dicCondition;               // 条件集合
            UserConditionModel conditionModel;                     // 条件模型
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                conditionModel = new UserConditionModel();
                userBusiness = new UserBusiness();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据删除
                conditionModel.OprationKind = AppConst.Operation_Delete;
                conditionModel.Id = Id;
                dicCondition = AppCommon.GetUserCondition(conditionModel);
                rtnValue = userBusiness.DeleteData(DbHelper.GetMysqlConnection(), dicCondition);

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
        /// 用户数据更新
        /// </summary>
        /// <param name="entity">用户数据</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] m_user entity)
        {
            InterfaceBusiness<m_user> userBusiness;                // 业务层对象
            QueryModel model;                                      // Json序列化对象
            List<m_user> lstUser;                                  // 用户数据集合
            int rtnValue = 0;                                      // 执行结果

            try
            {
                // 对象实例化
                userBusiness = new UserBusiness();
                lstUser = new List<m_user>();
                model = new QueryModel();

                // 创建WebApi数据库连接
                MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
                DbHelper.FirstCreateMysqlConnection();

                // 数据插入
                lstUser.Add(entity);
                rtnValue = userBusiness.UpdateData(DbHelper.GetMysqlConnection(), null, lstUser);

                model.State = 1;
                model.Data = lstUser;
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

        public async Task<string> Upload()
        {
            try
            {
                var root = System.Web.Hosting.HostingEnvironment.MapPath("/Attachments");
                var provider = new MultipartFormDataStreamProvider(root);

                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var item in provider.FileData)
                {
                    string filename = item.Headers.ContentDisposition.FileName.Trim('"');
                    string fileExt = filename.Substring(filename.LastIndexOf('.'));

                    FileInfo fileinfo = new FileInfo(item.LocalFileName);

                    string newFilename = fileinfo.Name + fileExt;

                    string saveUrl = Path.Combine(root, newFilename);
                    fileinfo.MoveTo(saveUrl);
                }
                return "success";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
