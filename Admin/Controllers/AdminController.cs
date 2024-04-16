using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopApp.Admin.Controllers
{
    public class AdminController : Controller
    {
        Db db = new Db();
        // GET: /Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var cat = db.Categories.ToList();

            return View(cat);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if(db.Categories.Any(x => x.NameFix == category.Name.Replace(" ", "-").ToLower().Replace("&", "-")))
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }
            else
            {
                Category cat = new Category()
                {
                    Name = category.Name.ToUpper(),
                    NameFix = category.Name.Replace(" ", "-").ToLower().Replace("&", "-"),
                    StatusNum = 1
                };
                db.Categories.Add(cat);
                db.SaveChanges();
                return View();
            }
        }
        [HttpGet]
         
        public ActionResult UpdateCategory(int id)
        {
            Category cat = db.Categories.Find(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {

            
            if (db.Categories.Any(x => x.NameFix == category.Name.Replace(" ", "-").ToLower().Replace("&", "-")))
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }
            else
            {
                Category cat = db.Categories.Find(category.Id);
                cat.Name = category.Name;
                cat.NameFix = category.Name.Replace(" ", "-").ToLower().Replace("&", "-");
                db.SaveChanges();
                return RedirectToAction("AddCategory");
            }
        }
    }
}