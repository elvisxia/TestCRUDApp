using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestCRUDApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{version}/{id}",
                defaults: new
                {
                    controller = "Test",
                    id = RouteParameter.Optional,
                    action = "GetById",
                    version = "v1"
                }
            );
        }
    }
}
