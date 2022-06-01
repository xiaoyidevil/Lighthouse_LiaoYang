using IWS_Business.Business;
using IWS_Business.Interface;
using IWS_Common.Const;
using IWS_Common.Model;
using IWS_Common.Mysql;
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
    /// 用户Controller
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户数据获取
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetUserData()
        {
            // 数据集合对象
            List<m_user> lstUser = new List<m_user>();

            // 创建WebApi数据库连接
            MysqlConnectionHelper DbHelper = new MysqlConnectionHelper(AppConst.Platform_Webapi);
            DbHelper.FirstCreateMysqlConnection();

            // 业务层访问对象
            InterfaceBusiness<m_user> userBusiness = new UserBusiness();
            var lst = userBusiness.SelectData(DbHelper.GetMysqlConnection(), null).ToList();

            // Json序列化返回
            string json = JsonConvert.SerializeObject(lst);
            return new HttpResponseMessage
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
