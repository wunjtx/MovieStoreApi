﻿using MovieStoreApi.Mvc.Infrastructure.Exception;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ExceptionLoggingFilter());
        }
    }
}
