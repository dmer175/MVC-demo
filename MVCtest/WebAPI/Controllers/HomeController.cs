using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //webapi 使用方式2 HTTPClient对象
        public ActionResult Index()
        {
            //客户端对象的创建与初始化
            HttpClient client = new HttpClient();
            //设置格式
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //执行get 读取 
            var response = client.GetAsync("http://localhost:25666/api/userinfo").Result;
            var list= response.Content.ReadAsAsync<List<UserInfo>>().Result;

            ViewData.Model = list;

            return View();
        }

    }
}
