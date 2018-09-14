using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFtest.Controllers
{
    public class MsgController : Controller
    {
        //
        // GET: /Msg/

        public ActionResult Index()
        {
            DbContext dbContext=new MyContextQQ();

            //连接查询 多表 1.
            //var list = from n in dbContext.Set<Messages>()
            //           join m in dbContext.Set<MessageType>() on n.MessageTypeId equals m.Id
            //           select n;
                     
            //2. 多from 查询  from后的 in 的后面必须是集合
            var list1 = from n in dbContext.Set<MessageType>()
                       from m in n.Messages
                        select new MsgTypeViewModel
                        { 
                            Id=m.Id,
                            Type=n.MessageType1
                       };
            ViewData.Model = list1;

            var list = from n in dbContext.Set<Messages>()
                       select new MsgTypeViewModel()
                       {
                           Id = n.Id,
                           Type = n.MessageType.MessageType1
                       };

            return View(list);
        }

    }
}
