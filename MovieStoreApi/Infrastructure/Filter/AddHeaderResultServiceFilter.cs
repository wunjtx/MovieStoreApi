using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using MovieStoreApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.Infrastructure.Filter
{
    //Add 
    public class AddHeaderResultServiceFilter : IResultFilter
    {
        private readonly ILoggerManager _iLoggerManager;
        private readonly IServiceProvider _serviceProvider;
        public AddHeaderResultServiceFilter(IServiceProvider serviceProvider,string str1,string str2,int i1)
        {
            //_logger = loggerFactory.CreateLogger<AddHeaderResultServiceFilter>();
            _serviceProvider = serviceProvider;
            _iLoggerManager =(ILoggerManager) _serviceProvider.GetService(typeof(ILoggerManager));
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
            _iLoggerManager.LogInfo($"Header added: {headerName}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't add to headers here because response has started.
        }
    }
}
