using MvcApplication2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    //身份验证第二种引用 对当前控制器中的所以行为起效
    //[MyAuthorization]
    [MyException]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //身份验证第一种引用 加特性 只对该行为有效 
        //[MyAuthorization]
        [MyAction]
        public ActionResult Index()
        {
            Response.Write("行为执行中");
            return View();
        }

    }
}
