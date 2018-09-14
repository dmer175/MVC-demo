using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class BookInfo1
    {
        [Key]
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        //[ForeignKey("BookType1")] //列与(表)关联
        public int TypeId { get; set; }

        public virtual BookType1 BookType1 { get; set; }
    }
}