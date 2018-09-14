using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class UsesController : Controller
    {

        BlogTestContext db = new BlogTestContext();
        //
        // GET: /Uses/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IndexGet(int id)
        {

            string acc = Request.Params["account"].ToString();
            string pwd = Request.Params["password"].ToString();

            var result = from u in db.Users
                         where u.Name == acc
                         where u.LoginPwd == pwd
                         select u;

            if (result != null && result.Count() > 0)
            {
                Response.Write("登录成功！");
            }
            else
            {
                Response.Write("登录失败！");
            }
                //db.Users.Where(i => i.Name == acc).Where(i => i.LoginPwd == pwd);

                return View();
        }

    }
}
