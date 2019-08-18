﻿using MovieStoreMovieStoreApi.Mvc.Infrastructure.Log;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MovieStoreApi.Mvc
{
    public class MvcApplication : HttpApplication
    {
        private readonly ILoggerManager loggerManager = (ILoggerManager) DependencyResolver.Current.GetService(typeof(ILoggerManager));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_Error()
        //{
        //    HttpContext httpContext = HttpContext.Current;
        //    if (httpContext != null)
        //    {
        //        RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
        //        /* When the request is ajax the system can automatically handle a mistake with a JSON response. 
        //           Then overwrites the default response */
        //        if (requestContext.HttpContext.Request.IsAjaxRequest())
        //        {
        //            httpContext.Response.Clear();
        //            string controllerName = requestContext.RouteData.GetRequiredString("controller");
        //            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        //            IController controller = factory.CreateController(requestContext, controllerName);
        //            ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

        //            JsonResult jsonResult = new JsonResult
        //            {
        //                Data = new { success = false, serverError = "500" },
        //                JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //            };
        //            jsonResult.ExecuteResult(controllerContext);
        //            httpContext.Response.End();
        //        }
        //        else
        //        {
        //            Exception exception = Server.GetLastError();
        //            loggerManager.LogError(exception.Message);
        //            httpContext.Response.Redirect("~/Error");
        //        }
        //    }
        //}

    }
}
