using MovieStoreApi.WebApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace MovieStoreApi.WebApi.Infrastructure.Exception
{
    public class WebAPiExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerManager _loggerManager = (ILoggerManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILoggerManager));
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            _loggerManager.LogError("Log from WebAPiExceptionHandler: " + context.Exception.Message);

            var httpResponse = context.Request.CreateResponse(HttpStatusCode.InternalServerError);

            context.Result = new ResponseMessageResult(httpResponse);

            return Task.FromResult(0);
        }
    }
}