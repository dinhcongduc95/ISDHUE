using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index(int? page)
        {           

            var result = db.Categories.ToList();

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(result.OrderBy(m => m.Id).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id, int?page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var products = db.Products.Where(m => m.Category.Id == id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.CategoryId = id;
            ViewBag.CategoryName = db.Categories.Find(id).Name;
            return View(products.OrderBy(m => m.Id).ToPagedList(pageNumber, pageSize));
        }

       
    }
}