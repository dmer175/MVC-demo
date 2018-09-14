using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class AjaxDemoController : Controller
    {
        //
        // GET: /AjaxDemo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalcAdd(int calc1, int calc2)
        {
            int sun = calc1 + calc2;
            return Content(sun.ToString());
        }
        [HttpPost]
        public ActionResult CalcAdd1(int calc1, int calc2)
        {
            int sun = calc1 + calc2;
            //var temp = new { sum = sun };
            //return Json(temp,JsonRequestBehavior.AllowGet);
            return PartialView("_pview",(object)sun);
        }
    }
}
