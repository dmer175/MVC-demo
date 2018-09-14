using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxDemo.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxTest(string message)
        {
            var a = message + "1";
            return PartialView((object)a);
        }
    }
}
