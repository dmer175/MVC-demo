using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class BookType1Controller : Controller
    {
        //
        // GET: /BookType1/
        DbContext dbContext = new MyContext();
        public ActionResult Index()
        {
            //当操作的表存在 则不进行创建, 若不存在 则创建
            dbContext.Database.Exists();
            //dbContext.Database.CreateIfNotExists();
            dbContext.SaveChanges();

            return View();
        }

    }
}
