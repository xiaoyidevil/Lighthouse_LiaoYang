using IWS_Webapi.Common;
using IWS_Webapi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace IWS_Webapi.Controllers
{
    public class SecurityTestController : ApiController
    {
        public IHttpActionResult GetToken() {
            string EncryptKeyString  = System.Configuration.ConfigurationManager.AppSettings["EncryptKeyString"].ToString();
            int TokenExpired = 1;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["EncryptKeyString"].ToString(), out TokenExpired);

            var dic = new Dictionary<string, object>();

            foreach (var queryNameValuePair in Request.GetQueryNameValuePairs())
            {
                dic.Add(queryNameValuePair.Key, queryNameValuePair.Value);
            }
            var token = new JWTHelper().Encode(dic, EncryptKeyString, TokenExpired);

            return Ok(token);
        }

        public IHttpActionResult GetUser()
        {
            var user = (ClaimsPrincipal)User;
            var dic = new Dictionary<string, object>();
            foreach (var userClaim in user.Claims)
            {
                dic.Add(userClaim.Type, userClaim.Value);
            }

            return Ok(dic);
        }

        #region 硬编码的方式实现简单的权限控制


        /// <summary>
        /// 只有某种角色的用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("byCode/onlyRoles"), RBAuthorizeAttribute(Roles = "admin,superAdmin"), HttpGet]
        //[HttpGet]
        public IHttpActionResult OnlyRoles_SetByCode() 
        {
            return Ok("OnlyRoles_SetByCode,仅管理员能访问");
        }

        /// <summary>
        /// 只有某几个用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("byCode/onlyUsers"), HttpGet]
        public IHttpActionResult OnlyUsers_SetByCode()
        {
            return Ok("OnlyUsers_SetByCode, 仅张三和李四才能访问");
        }
        #endregion
    }
}
