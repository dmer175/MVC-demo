using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class Person
    {
        public int Age { get; set; }

        public string QQ { get; set; }

        //[Range]//范围
        //[StringLength(16)]//字符串长度
        //必须的
        [Required(ErrorMessage="编号不为空")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //扩展方法 得到类的对象 使用的方法是自己扩展出的
    //必须静态
    public static class Class1
    {
        //say方法被扩展到person类的对象上
        public static void say(this Person person,string age)
        {

        }
    }

}