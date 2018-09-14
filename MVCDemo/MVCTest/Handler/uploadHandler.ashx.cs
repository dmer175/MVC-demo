using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Handler
{
    /// <summary>
    /// uploadHandler 的摘要说明
    /// </summary>
    public class uploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpFileCollection myFile = context.Request.Files;
            //HttpPostedFile myFile = context.Request.Files["flContent"];
            if (myFile != null && myFile.Count > 0)
            {
                string path = context.Server.MapPath("../Images/" + myFile[0].FileName);
                myFile[0].SaveAs(path);
                context.Response.Write("../../Images/" + myFile[0].FileName);
            }
            //context.Response.Write("Hello World");
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