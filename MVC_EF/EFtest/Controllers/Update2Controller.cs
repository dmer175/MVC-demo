using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFtest.Controllers
{
    public class Update2Controller : Controller
    {
        //延迟加载 如果不适用数据 则只是拼接sql语句 不会将结果拿到内存中来

        //
        // GET: /Update2/

        DbContext dbContext=new MyContextQQ();
        //状态跟踪的修改
        public ActionResult Index()
        {
            //导航属性多表联查

            ViewData.Model = from m in dbContext.Set<Messages>() select m;
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model= dbContext.Set<Messages>().Where(m => m.Id == id).FirstOrDefault();


            return View();
        }
        [HttpPost]
        public ActionResult Edit(Messages msg)
        {
            //使用状态方式进行修改
            dbContext.Set<Messages>().Attach(msg);
            //修改整个对象
            //dbContext.Entry(msg).State = System.Data.EntityState.Modified;

            //修改单独列
            dbContext.Entry(msg).Property("Messages1").IsModified = true;
            dbContext.Entry(msg).Property("Messages1").CurrentValue = msg.Messages1;

            dbContext.SaveChanges();


            return Redirect(Url.Action("Index"));
        }

    }
}
