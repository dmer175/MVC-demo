using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UserInfoController : ApiController
    {
        // GET api/userinfo
        //WebAPI的两种网络服务
        //WebService:基于SOAP风格的网络服务 使用方法进行请求
        //WebAPI:基于REST风格的网络服务 使用资源进行请求 5个方法
        //基于资源
        //使用方式1: jQuery的ajax (不支持跨域操作)
        //使用Method=Get的方式请求url=api/userinfo 则这个方法会被调用
        public IEnumerable<UserInfo> Get()
        {
            List<UserInfo> list = new List<UserInfo>();
            list.Add(new UserInfo()
            {
                Id = 1,
                Name = "csa"
            });
            list.Add(new UserInfo()
            {
                Id = 2,
                Name = "wda"
            });
            list.Add(new UserInfo()
            {
                Id = 3,
                Name = "cgegsa"
            });
            return list;
        }

        // GET api/userinfo/5
        //查询单条信息
        public string Get(int id)
        {
            return "value";
        }

        // POST api/userinfo
        public void Post([FromBody]string value)
        {
        }

        //支持命名修改
        //[HttpPost]
        //public void Add(string value)
        //{

        //}

        // PUT api/userinfo/5
        //可完成自动装配
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/userinfo/5
        public void Delete(int id)
        {
        }
    }
}
