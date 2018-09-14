using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //在MVC中,访问时 实际访问的是某个类的某个方法
        //在asp.net中访问的是某个类
        // GET: /Home/
        //行为 : action
        //控制器:Controller
        //视图 view
        //路由 Route
        public ActionResult Index()
        {
            //默认不置顶显示页面时,会采用与行为同名的页面进行显示
            //可自定义页面
            return View();
        }

        public ActionResult HtmlTest()
        {

            //从行为 向视图传数据
            ViewData["user"] = "薇薇安";
            //自定义键值 QQ
            ViewBag.QQ = "175";

            //下拉列表
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Selected=false,
                Text="faef",
                Value="1"
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

            Person per = new Person();
            per.say("");

            //必须和页面的类型对应
            ViewData.Model = new Person()
                {
                    Age=10,
                    QQ="123"
                };


            return View();
        }

        public ActionResult Say()
        {
            //返回结果
            /* ViewResult:使用View() 指定一个页面,也可以指定传递的模型对象
             *  如果没有指定参数则表示返回与Action同名的页面
             * ContentResult:使Content(string contnet)返回一个原始字符串
             * RedirectResult:使用Redirect(string url)将结果转到其他的Action
             * JsonResult:使用Json(object data)间data序列化为惊悚数据并返回/默认post
             * JsonRequestBehavior.AllowGet可以处理Get请求和post
             *  一般结合客户端的ajax请求进行返回*/

            //return Content("123");
            //return Redirect(Url.Action("Index", "Home"));

            Person per = new Person()
            {
                Age = 10,
                QQ = "123"
            };
            return Json(per, JsonRequestBehavior.AllowGet);

        }
        //[HttpGet]
        //1.Request["键"]的方式接受参数
        public ActionResult Add()
        {
            //视图向行为传递参数
            /*
             *1.Request["键"]的方式接受参数
             *2.自动装配 
             *  如果要实现行为的重载 满足两个条件 a.参数不同,b.请求类型不同
             */

            int id = int.Parse(Request["id"]);
            ViewBag.Id = id;
            return View();
        }

        //2.自动装配 使用形参来接受页面传来的值  Html.TextBox("id") 的键值要与形参一致
             //*  如果要实现行为的重载 满足两个条件 a.参数不同,b.请求类型不同
        //也表现了一个视图多个行为 解耦 即页面的重用
        [HttpPost]
        public ActionResult Add(int id,string action)
        {
            ViewBag.Action = action;
            ViewBag.Id2 = id;
            return View();
        }
        
        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        //自动装配 可以完成自定义类型的参数的自动装配
            //person=new person();
            //person.age=request["age"];
        public ActionResult AddPerson(Person per)
        {
            ViewData.Model = per;
            return View("AddPerson1");
        }
    }
}
