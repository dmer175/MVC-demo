using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class BookType1
    {
        public BookType1()
        {
            BookInfo1 = new HashSet<BookInfo1>();
        }
        [Key]
        public int TypeId { get; set; }
        public string TypeTitle { get; set; }

        //virtual 可实现延迟加载
        public virtual ICollection<BookInfo1> BookInfo1 { get; set; }
    }
}