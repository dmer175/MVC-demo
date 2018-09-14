using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class QueryDemoController : Controller
    {
        BlogTestContext db = new BlogTestContext();
        //
        // GET: /QueryDemo/

        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            //ViewBag.name = users;
            //ViewData["name"] = users;
            TempData["name"] = users;
            return View();
        }

    }
}
