using MovieStoreMovieStoreApi.Mvc.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.Mvc.Infrastructure.Exception
{
    public class ExceptionHandlingController:Controller
    {
        private readonly ILoggerManager _loggerManager;
        public ExceptionHandlingController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!
            _loggerManager.LogError("Log from ExceptionHandlingController: " + filterContext.Exception.Message);

            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
            // OR 
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}