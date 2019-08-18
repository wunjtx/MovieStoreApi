using MovieStoreMovieStoreApi.Mvc.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.Mvc.Infrastructure.Exception
{
    public class ExceptionLoggingHandlerAttribute : HandleErrorAttribute
    {
        private readonly ILoggerManager _loggerManager = DependencyResolver.Current.GetService<ILoggerManager>();

        public override void OnException(ExceptionContext filterContext)
        {
            _loggerManager.LogError("Log from ExceptionLoggingHandlerAttribute: "+filterContext.Exception.Message);
        }
    }
}