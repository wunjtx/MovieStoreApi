using MovieStoreApi.WebApi.Infrastructure.Exception;
using MovieStoreApi.WebApi.Infrastructure.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace MovieStoreApi.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.MessageHandlers.Add(new CustomEventHandler());
            //config.Filters.Add(new ExceptionHandlingAttribute());
            config.Services.Replace(typeof(IExceptionHandler), new WebAPiExceptionHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ) ;

            config.Routes.MapHttpRoute(
                name: "Api2",
                routeTemplate: "api2/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: new CustomEventHandler(GlobalConfiguration.Configuration)
            );
        }
    }
}
