﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Filters
{
    public class MyAction:ActionFilterAttribute
    {
        //行为执行前 处理的代码
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("ing<br>");
        }
        //行为执行后 处理的代码
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("ed");
        }
    }
}