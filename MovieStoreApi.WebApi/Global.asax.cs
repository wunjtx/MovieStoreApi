using MovieStoreApi.WebApi.Infrastructure.Exception;
using MovieStoreApi.WebApi.Infrastructure.Handler;
using MovieStoreApi.WebApi.Infrastructure.Invoker;
using MovieStoreApi.WebApi.Infrastructure.Log;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MovieStoreApi.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ILoggerManager _loggerManager = (ILoggerManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILoggerManager));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalConfiguration.Configuration .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")) .EnableSwaggerUi();

            //GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpActionInvoker), new  MyApiControllerActionInvoker());
            //GlobalConfiguration.Configuration.Filters.Add(new ExceptionHandlingAttribute());
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());
        }

        //web api exception can not fire httpmodule.onerror event, below can not work
        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            _loggerManager.LogError("Log from Application_Error: "+exception.Message);
        }
    }
}
