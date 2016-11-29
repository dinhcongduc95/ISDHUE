using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using WebApplication5.Models;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    public class CartsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Carts
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            
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

            var userId = User.Identity.GetUserId();
            var shoppingCart = db.ShoppingCarts.SingleOrDefault(m => m.UserIdRef.Equals(userId));
            
                IEnumerable<Product> products = from p in db.Products
                    join pc in db.CartProducts on p.Id equals pc.ProductIdRef
                    where pc.ShoppingCart_Id == shoppingCart.Id
                    select p;
            if (shoppingCart == null)
            {
                return View("Error");
            }

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

        public ActionResult AddToCart(int productId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            string message = "";
            var userId = User.Identity.GetUserId();
            // Mỗi khi tạo user đều tạo 1 cart tương ứng với user nên ko cần check null
            var shoppingCart = db.ShoppingCarts.SingleOrDefault(m => m.UserIdRef.Equals(userId));
            var isInCart = db.CartProducts.Where(m => m.ProductIdRef == productId).Any(m => m.ShoppingCart_Id == shoppingCart.Id);
            if (isInCart)
            {
                message = "Sản phẩm đã nằm trong giỏ hàng của bạn rồi";
            }

            if (String.IsNullOrEmpty(message))
            {

                db.CartProducts.Add(new CartProduct
                {
                    ProductIdRef = productId,
                    ShoppingCart_Id = shoppingCart.Id
                });
            }            
            
            return RedirectToAction("Details", "Products", new { id = productId, msg = message });
        }
    }
}