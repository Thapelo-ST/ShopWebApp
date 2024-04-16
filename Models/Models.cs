using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopApp.Models
{
    public class Models
    {
    }

    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameFix { get; set; }
        public int StatusNum { get; set; }
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int Counter { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}