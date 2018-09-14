using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //路由 控制url访问顺序
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //自定义路由规则的要求 小范围写在前面 大范围写在后面
            //2018-1-1
            routes.MapRoute(
                name: "NewsShow",
                url: "{year}-{month}-{day}-{id}",
                defaults: new
                {
                    Controller="News",
                    Action="Show"
                },
                constraints: new
                {
                    year="^\\d{4}$",
                    month="^\\d{1,2}$",
                    day="^\\d{1,2}$"
                }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}