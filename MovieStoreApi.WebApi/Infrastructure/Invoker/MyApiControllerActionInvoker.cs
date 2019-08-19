using MovieStoreApi.WebApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MovieStoreApi.WebApi.Infrastructure.Invoker
{
    public class MyApiControllerActionInvoker : ApiControllerActionInvoker
    {
        private readonly ILoggerManager _loggerManager = (ILoggerManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILoggerManager));
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            var result = base.InvokeActionAsync(actionContext, cancellationToken);

            if (result.Exception != null && result.Exception.GetBaseException() != null)
            {
                var baseException = result.Exception.GetBaseException();

                _loggerManager.LogError("Log from MyApiControllerActionInvoker: " + baseException.Message);
            }
            else
            {
                _loggerManager.LogError("Log from MyApiControllerActionInvoker: " + result.Status);
            }
            return result;
        }
    }
}