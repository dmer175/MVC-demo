using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Handler
{
    /// <summary>
    /// AjaxDemoHandler 的摘要说明
    /// </summary>
    public class AjaxDemoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Params["demoData"] != null)
            {
                string data = context.Request.Params["demoData"].ToString();
                if (!string.IsNullOrEmpty(data))
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}