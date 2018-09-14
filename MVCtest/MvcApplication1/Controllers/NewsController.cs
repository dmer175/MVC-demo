using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id,int year)
        {
            ViewBag.Year = year;
            ViewBag.Id = id;
            return View();
        }
    }
}
