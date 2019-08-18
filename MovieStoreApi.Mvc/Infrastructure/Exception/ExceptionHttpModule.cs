using MovieStoreMovieStoreApi.Mvc.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.Mvc.Infrastructure.Exception
{
    public class ExceptionHttpModule : IHttpModule
    {
        private readonly ILoggerManager _loggerManager = DependencyResolver.Current.GetService<ILoggerManager>();
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(OnError);
        }

        private void OnError(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;
            HttpResponse response = ctx.Response;
            HttpRequest request = ctx.Request;

            System.Exception exception = ctx.Server.GetLastError();

            _loggerManager.LogError("Log from module: "+exception.Message);

            /*
            response.Write("Your request could not processed. " +
                           "Please press the back button on" +
                           " your browser and try again.<br/>");
            response.Write("If the problem persists, please " +
                           "contact technical support<p/>");
            response.Write("Information below is for " +
                           "technical support:<p/>");

            string errorInfo = "<p/>URL: " + ctx.Request.Url.ToString();
            errorInfo += "<p/>Stacktrace:---<br/>" +
               exception.InnerException.StackTrace.ToString();
            errorInfo += "<p/>Error Message:<br/>" +
               exception.InnerException.Message;

            //Write out the query string 
            response.Write("Querystring:<p/>");

            for (int i = 0; i < request.QueryString.Count; i++)
            {
                response.Write("<br/>" +
                     request.QueryString.Keys[i].ToString() + " :--" +
                     request.QueryString[i].ToString() + "--<br/>");// + nvc.
            }

            //Write out the form collection
            response.Write("<p>---------------" +
                           "----------<p/>Form:<p/>");

            for (int i = 0; i < request.Form.Count; i++)
            {
                response.Write("<br/>" +
                         request.Form.Keys[i].ToString() +
                         " :--" + request.Form[i].ToString() +
                         "--<br/>");// + nvc.
            }

            response.Write("<p>-----------------" +
                           "--------<p/>ErrorInfo:<p/>");

            response.Write(errorInfo);

            // --------------------------------------------------
            // To let the page finish running we clear the error
            // --------------------------------------------------
            */

            ctx.Server.ClearError();
        }

    }
}