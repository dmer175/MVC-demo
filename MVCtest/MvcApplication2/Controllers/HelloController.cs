using MvcApplication2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HelloController : Controller
    {
        //
        // GET: /Hello/
        [MyException]
        public ActionResult Index()
        {
            //可以自定义异常
            throw new Exception("");
            return View();
        }

        //过滤器第二种实现方式:重写控制器的方法 会应用于所有行为
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("486");
        }
    }
}
