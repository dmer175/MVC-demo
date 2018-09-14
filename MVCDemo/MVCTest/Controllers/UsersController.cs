using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class UsersController : Controller
    {

        public BlogTestContext db = new BlogTestContext();
        //
        // GET: /Users/



        public string ShowInfo(string aa)
        {
            return "sdfsdf";
        }

        public ActionResult ShowList()
        {
            var model = db.Users.ToList();
            return View(model);
        }

        public ActionResult MasterDemo()
        {
            return View();
        }
        public ActionResult Index()
        {

            if (Request.IsAjaxRequest())
            {
                if (Request.Params["demoData"] != null)
                {
                    string data = Request.Params["demoData"].ToString();
                    if (!string.IsNullOrEmpty(data))
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                    return null;
                }

            }
            else
            {
                if (Request.Params["account"] != null)
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
                }

            }
            return View();

        }

        public ActionResult Patial()
        {

            User u = new User();
            u.LoginPwd = "888888";
            u.Mail = "2969486052@qq.com";
            u.Name = "张三";
            u.QQ = "2969486052";
            u.LoginId = "1234";
            // ViewBag.user = u;
            // return PartialView("PatialDemo");
            return PartialView("PatialDemo", u);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterPost()
        {
            User u = new MVCTest.User();
            u.LoginId = Request.Params["txtaccount"].ToString();
            u.LoginPwd = Request.Params["txtpassword"].ToString();
            u.Name = Request.Params["txtname"].ToString();
            u.QQ = Request.Params["txtqq"].ToString();
            u.Mail = Request.Params["txtemail"].ToString();

            db.Users.Add(u);
            db.SaveChanges();

            return View("Register");
        }


        public ActionResult RegisterModel()
        {
            return View();
        }
        
       [HttpPost]
        public ActionResult RegisterModelFor(User u)
        {
            if (u != null)
            {
                db.Users.Add(u);
                db.SaveChanges();

                return View("Register");
            }
            else
            {
                Response.Write("失败");
                return View("RegisterModel");
            }
            //User u = new MVCTest.User();
            //u.LoginId = Request.Params["txtaccount"].ToString();
            //u.LoginPwd = Request.Params["txtpassword"].ToString();
            //u.Name = Request.Params["txtname"].ToString();
            //u.QQ = Request.Params["txtqq"].ToString();
            //u.Mail = Request.Params["txtemail"].ToString();

        
        }
        
    }
}
