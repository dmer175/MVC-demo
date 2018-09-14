using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class MyContext:DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add<PluralizingTableNameConvention>(,);
        }
        public DbSet<BookInfo1> BookInfo { get; set; }
        public DbSet<BookType1> BookType { get; set; }
    }
}