using MvcApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //行为
        public ActionResult Index()
        {
            ViewData["test"] = 123;
            ViewBag.Test1 = 123;



            return View();
        }


        public ActionResult Add()
        {
            //int cc = int.Parse(Request["cc"]);
            //ViewBag.cc = cc;


            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Selected = false,
                Text = "faef",
                Value = "1"
            });

            list.Add(new SelectListItem()
            {
                Selected = false,
                Text = "grhr",
                Value = "2"
            });

            list.Add(new SelectListItem()
            {
                Selected = true,
                Text = "hrh",
                Value = "3"
            });
            ViewBag.list = list;


            Student stu = new Student() { 
                Sid=123,
                Name="zz"
            };

            ViewData.Model = stu;


            return View();
        }

        [HttpGet]
        public ActionResult AddStu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStu(Student stu)
        {
            ViewData.Model = stu;

            return View("AddStu1");
        }

        public ActionResult View1()
        {
            return View();
        }

        public ActionResult And(int calc1,int calc2)
        {
            int s = calc1 + calc2;

            return Content(s.ToString());
        }

        public ActionResult And1(int calc1, int calc2)
        {
            int s=calc1+calc2;
            var ss=new {ss=s};
            return Json(ss,JsonRequestBehavior.AllowGet);
        }
    }
}
