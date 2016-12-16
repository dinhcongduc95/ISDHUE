using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = from p in db.Products
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    products = products.OrderBy(s => s.CreateDate);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.CreateDate);
                    break;
                default:  // Name ascending 
                    products = products.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id, int? page, string msg = "")
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Product = product;
            var reviews = db.Reviews.Include(m => m.User).Where(m => m.ProductIdRef == id);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.Message = msg;
            return View(reviews.OrderBy(m => m.Id).ToPagedList(pageNumber, pageSize));
        }        

        [HttpPost]
        public ActionResult AddReview()
        {
            var producId = Int32.Parse(Request["productId"]);
            var point = Int32.Parse(Request["point"]);    
                    
            Product product = db.Products.Find(producId);
            if (product == null)
            {
                return HttpNotFound();
            }
            var newReview = new Review
            {
                CreateDate = DateTime.Now.ToShortDateString(),
                User = db.Users.Find(User.Identity.GetUserId()),
                ProductIdRef = producId,
                Description = Request["addComment"],
                Point = point
            };

            db.Reviews.Add(newReview);
            db.SaveChanges();

            return RedirectToAction("Details", "Products", new {id = producId});            
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
