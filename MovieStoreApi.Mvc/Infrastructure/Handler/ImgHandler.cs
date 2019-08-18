using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreApi.Mvc.Infrastructure.Handler
{
    public class MyJpgHandler : IHttpHandler
    {

        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            // Do something
        }
    }
}