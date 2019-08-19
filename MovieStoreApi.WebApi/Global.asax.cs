using MovieStoreApi.WebApi.Infrastructure.Exception;
using MovieStoreApi.WebApi.Infrastructure.Handler;
using MovieStoreApi.WebApi.Infrastructure.Invoker;
using MovieStoreApi.WebApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
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

            
            //GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpActionInvoker), new  MyApiControllerActionInvoker());
            //GlobalConfiguration.Configuration.Filters.Add(new ExceptionHandlingAttribute());
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());
        }

        //web api exception can not fire httpmodule.onerror event, below can not work
        protected void Application_Error()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
                /* When the request is ajax the system can automatically handle a mistake with a JSON response. 
                   Then overwrites the default response */
                if (requestContext.HttpContext.Request.IsAjaxRequest())
                {
                    httpContext.Response.Clear();
                    string controllerName = requestContext.RouteData.GetRequiredString("controller");
                    IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
                    IController controller = factory.CreateController(requestContext, controllerName);
                    ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

                    JsonResult jsonResult = new JsonResult
                    {
                        Data = new { success = false, serverError = "500" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    jsonResult.ExecuteResult(controllerContext);
                    _loggerManager.LogError("Log from Application_Error: AjaxException");
                    httpContext.Response.End();
                }
                else
                {
                    Exception exception = Server.GetLastError();
                    _loggerManager.LogError("Log from Application_Error: "+exception.Message);
                    httpContext.Response.Redirect("~/Error");
                }
            }
        }

    }
}
