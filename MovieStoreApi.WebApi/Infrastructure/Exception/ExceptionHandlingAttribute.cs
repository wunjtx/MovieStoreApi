using MovieStoreApi.WebApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace MovieStoreApi.WebApi.Infrastructure.Exception
{
    public class ExceptionHandlingAttribute: ExceptionFilterAttribute
    {
        //the System.Web.Mvc.DependencyResolver can not resolve service
        //private readonly ILoggerManager _loggerManager = DependencyResolver.Current.GetService<ILoggerManager>();

        //for web api DependencyResolver
        private readonly ILoggerManager _loggerManager = (ILoggerManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILoggerManager));
        public override void OnException(HttpActionExecutedContext context)
        {
            _loggerManager.LogError("Log from ExceptionHandlingAttribute: "+ context.Exception.Message);
        }
    }
}