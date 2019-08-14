using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using MovieStoreApi.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MovieStoreApi.Infrastructure.Filter
{
    //add to global
    public class LogConstantFilter : IActionFilter
    {
        private readonly string _value;
        private readonly ILoggerManager _iLoggerManager;
        private readonly IServiceCollection _services;

        public LogConstantFilter(string value, IServiceCollection services)
        {
            _value = value;
            _iLoggerManager = services.BuildServiceProvider().GetService<ILoggerManager>();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _iLoggerManager.LogInfo(_value);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
}
