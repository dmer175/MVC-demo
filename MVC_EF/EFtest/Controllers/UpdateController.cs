using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity.Migrations;

namespace EFtest.Controllers
{
    public class UpdateController : Controller
    {
        //
        // GET: /Update/
        DbContext dbContext = new MyContextQQ();
        MyContextQQ db = new MyContextQQ();
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

        public ActionResult Index()
        {
            //var list = dbContext.Set<Messages>();
            var list= db.Messages.Where(n=>n.Id==1);
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(string str)
        {
            //var list = dbContext.Set<Messages>().Where(n => n.Messages1 == str);  
            var list = db.Messages.Where(n => n.Messages1 == str).ToList();
            //db.Messages.FirstOrDefault(x=>string.Equals(x.Messages1,str,StringComparison.CurrentCultureIgnoreCase))
            //var list1 = js.Serialize(list);
            var list1 = new { list = list.FirstOrDefault() };
            return View(js.Serialize(list1));
        }

        public ActionResult Result(string str)
        {
            var list = dbContext.Set<Messages>().Where(n => n.Messages1 == str);
            return Json(js.Serialize(list), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Messages msg)
        {
            dbContext.Set<Messages>().Add(msg);
            //内存中数据发生变化 并且想将这个变化映射到数据库 需执行这个方法
            int result= dbContext.SaveChanges();

            if (result > 0)
            {
                return Redirect(@Url.Action("Index", "Update"));
            }
            else
            {
                return Redirect(@Url.Action("Add"));
            }
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = dbContext.Set<Messages>().Where(u => u.Id == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Messages msg)
        {
            dbContext.Set<Messages>().Where(m=>m.Id==msg.Id).FirstOrDefault().Messages1=msg.Messages1;

            //dbContext.Set<Messages>().AddOrUpdate(msg);
            int result = dbContext.SaveChanges();

            if (result > 0)
            {
                return Redirect(@Url.Action("Index", "Update"));
            }
            else
            {
                return RedirectToAction("Edit", new RouteValueDictionary(new { id = msg.Id }));
            }

            //return Redirect(Url.Action("Index"));
        }

        public ActionResult Remove(int id)
        {
            var msg = dbContext.Set<Messages>().Where(m => m.Id == id).FirstOrDefault();
            dbContext.Set<Messages>().Remove(msg);
            dbContext.SaveChanges();
            return Redirect(Url.Action("Index"));
        }
    }
}
