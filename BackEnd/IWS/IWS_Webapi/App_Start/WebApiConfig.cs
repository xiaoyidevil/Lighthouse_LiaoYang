using IWS_Webapi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IWS_Webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new IdentityBasicAuthentication());
        }
    }
}
