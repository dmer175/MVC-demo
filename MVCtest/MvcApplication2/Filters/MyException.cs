using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Filters
{
    public class MyException:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //异常过滤器

            //如下代码不可被删除 否则捕获不到异常
            base.OnException(filterContext);

            //日志记录

            //页面跳转
            filterContext.Result = new RedirectResult("/Error/400.html");
        }
    }
}