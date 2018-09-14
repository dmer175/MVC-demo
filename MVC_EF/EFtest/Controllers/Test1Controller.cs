using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFtest.Controllers
{
    public class Test1Controller : Controller
    {
        //
        // GET: /Test1/
        DbContext dbContext = new MyContextQQ();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var list = dbContext.Set<User>().Where(u => u.Id == user.Id).Where(u => u.LoginPwd == user.LoginPwd).FirstOrDefault();
            if (list != null)
            {
                return Redirect(@Url.Action("Index"));
            }
            else
            {
                //return Redirect(@Url.Action("Login"));
                return Content("未成功");
            }

        }

        public ActionResult Result(int id)
        {
            var uid = dbContext.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            if (uid != null)
            {
                return Content("存在");
            }
            else
            {
                return Content("bucunza");
            }

        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            dbContext.Set<User>().Add(user);
            int re = dbContext.SaveChanges();

            if (re>0)
            {
                return Content("成功");
            }
            else
            {
                return Content("失败");
            }
            
        }
    }
}
