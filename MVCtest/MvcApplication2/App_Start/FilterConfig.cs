using MvcApplication2.Filters;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //系统默认的异常处理过滤器 如果使用自定义异常处理 以下代码需删除
            //filters.Add(new HandleErrorAttribute());
            //身份验证第三种方法 全局
            //在全局中注册过滤器 则所有控制器的所有行为 都会执行整个过滤器
            //filters.Add(new MyAuthorization());


            //异常处理器
            filters.Add(new MyException());

        }
    }
}