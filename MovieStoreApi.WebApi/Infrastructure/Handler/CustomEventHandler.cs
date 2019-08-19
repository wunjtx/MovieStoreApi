using MovieStoreApi.WebApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace MovieStoreApi.WebApi.Infrastructure.Handler
{
    public class CustomEventHandler: DelegatingHandler
    {
        public CustomEventHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }
        private readonly ILoggerManager _loggerManager = (ILoggerManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILoggerManager));
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Call the inner handler.  
            var response = await base.SendAsync(request, cancellationToken);
            response.Headers.Add("X-Powered-By", "DotnetPiper : Value returned from CustomHandler One.");
            _loggerManager.LogInfo("Log from CustomEventHandler: "+request.RequestUri.AbsoluteUri);
            return response;
        }
    }
}