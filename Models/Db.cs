using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopApp.Models
{
    public class Db : DbContext
    {
        //public Db() : base("ShopApp")
        //{
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}