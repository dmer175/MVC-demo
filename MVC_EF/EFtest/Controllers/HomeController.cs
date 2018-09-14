using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFtest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            MyContext myContext = new MyContext();
            //查询语法 
            //var list=from n in myContext.bank
            //             select n; 

            //方法语法
            //var list = myContext.bank.Select(u => u);


            //*面向抽象的写法 声明父类型指向子类型对象
            //面向多态的开始
            //DbContext dbContext = new MyContext();
            ////等价 myContext.bank
            //var list = dbContext.Set<bank>().Select(u => u);

            IQueryable<bank> list;

            //创建上下文对象
            DbContext dbContext = new MyContext();

            //基本查询
            //list = from n in dbContext.Set<bank>() select n;

            //单条件查询
            list = from n in dbContext.Set<bank>() where n.cardId=="1001 0001" select n;
            
            //多条件
            list = from n in dbContext.Set<bank>()
                   where n.cardId == "1001 0001" && n.customerName.Length > 2
                   select n;

            //查询单列
            var list1 = from n in dbContext.Set<bank>() select n;

            //查询多列
            //需要新建显示model bankViewModel
            var list2 = from n in dbContext.Set<bank>()
                        select new BankViewModel
                        { 
                Id=n.cardId,
                Name=n.customerName
            };

            //分页 仅lambda
            var list3 = from n in dbContext.Set<bank>() select n;
            //要先排序
            //list3 = list3.Skip(2).Take(3);
            list3 = list3.OrderByDescending(u => u.cardId).Skip(2).Take(3);
            

            return View(list);
        }

        public ActionResult Index2()
        {
            //方法查询
            DbContext dbContext = new MyContext();

            //基本查询
            var list = dbContext.Set<bank>();

            IQueryable<bank> list1;
            //单条件
            //var list1 = list.Where(u => u.currentMoney>950);

            //多条件
            //list1 = list.Where(u => (u.cardId == "1000 0001") || (u.customerName.Contains("张")));
            list1 = list.Where(u => u.cardId == "1000 0001")
                .Where(u=>u.customerName.Contains("张"));
            
            list1 = list.Where(u => u.cardId == "1000 0001");
            //部分列
            //list1 = list.Select(u => new BankViewModel()
            //{
            //    Id = u.cardId,
            //    Name = u.customerName
            //});

            return View(list1);
        }

    }
}
