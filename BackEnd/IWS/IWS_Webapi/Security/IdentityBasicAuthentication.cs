﻿using IWS_Webapi.Common;
using JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace IWS_Webapi.Security
{
    public class IdentityBasicAuthentication: IAuthenticationFilter
    {
        public bool AllowMultiple { get; }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {

            string EncryptKeyString = System.Configuration.ConfigurationManager.AppSettings["EncryptKeyString"].ToString();
            int TokenExpired = 60;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["TokenExpired"].ToString(), out TokenExpired);

            //1. get token
            context.Request.Headers.TryGetValues("token", out var tokenHeaders);
            if (tokenHeaders == null || !tokenHeaders.Any())
            {
                return Task.FromResult(0);
            }

            //3. if token is through authenticate, write to identity, if token is incorrect, set up wrong info
            var jwtHelper = new JWTHelper();
            var payLoadClaims = jwtHelper.DecodeToObject(tokenHeaders.FirstOrDefault(), EncryptKeyString, out bool isValid, out string errMsg);

            if (isValid)
            {
                //只要ClaimsIdentity设置了authenticationType，authenticated就为true，后面的authority根据authenticated=true来做权限
                var identity = new ClaimsIdentity("jwt", "userId", "roles");

                UtcDateTimeProvider _dateTimeProvider = new UtcDateTimeProvider();
                double currExp = Math.Round((_dateTimeProvider.GetNow() - new DateTime(1970, 1, 1)).TotalSeconds);
                string strExp = payLoadClaims["exp"].ToString();
                double dblExp = 0;
                double.TryParse(strExp, out dblExp);

                if (currExp - dblExp > TokenExpired)
                {
                    context.ErrorResult = new ResponseMessageResult(new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.ProxyAuthenticationRequired,
                        Content = new StringContent("token 超时请重新登录")
                    }); ;
                }

                foreach (var keyValuePair in payLoadClaims)
                {
                    identity.AddClaim(new Claim(keyValuePair.Key, keyValuePair.Value.ToString()));
                }
                // 最好是http上下文的principal和进程的currentPrincipal都设置
                context.Principal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = new ClaimsPrincipal(identity);
            }
            else
            {
                context.ErrorResult = new ResponseMessageResult(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ProxyAuthenticationRequired,
                    Content = new StringContent(errMsg)
                }); ;

            }
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}