using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Filters
{
    public class MyAuthorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //身份验证过滤器

            //过滤器第1种实现方式 新写一个类

            //保留则会运行,net framework定义好的身份验证 如果希望自定义身份验证 则不需要
            //base.OnAuthorization(filterContext);

            //如果希望跳转到另一页面 使用Result 而不是使用 Response.Redirect() 该方法不会让服务器端停止运行
            //filterContext.Result = new RedirectResult(UrlHelper.GenerateUrl("","Login","UserInfo",));

            //获取路由数据 当前上下文匹配到路由规则后 得到的一个对象
            //filterContext.RouteData

            //获取上下文
            filterContext.HttpContext.Response.Write("121");

        }
    }
}