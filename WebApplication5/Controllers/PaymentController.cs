using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class PaymentController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePayment(int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var msg = "";

            var products = GetProducts();
            if (!products.Any())
            {
                msg = "Giỏ hàng của bạn không có sản phẩm nào cả";
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(products.OrderBy(m => m.Id).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CheckOut()
        {
            var productId = Int32.Parse(Request.Form["productId"]);
            var product = db.Products.SingleOrDefault(m => m.Id == productId);
            ViewBag.Locations = new SelectList(db.Locations, "Id", "Name");
            ViewBag.Product = product;
             


            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(Product model)
        {
            var productId = Int32.Parse(Request.Form["productId"]);
            var description = Request.Form["description"];
            var price = Request.Form["price"];
            var locationId = Int32.Parse(Request.Form["locationId"]);
            var product = db.Products.SingleOrDefault(m => m.Id == productId);
            var shippingId = db.Shippings.OrderBy(m => m.Id).First().Id + 1;
            var shipping = new Shipping
            {
                Id = shippingId,
                Description = description,
                DeadLine = DateTime.Now.AddDays(10).ToShortDateString(),
                LocationIdRef = locationId,
                Name = "Đơn Hàng của khách " + User.Identity.Name,
                PaymentType = "Tiền mặt",
                PhoneNo = "098832838",             
            };

            var payment = new Payment
            {
                Amount = price,
                UserIdRef = User.Identity.GetUserId(),
                Currency = "VND",
                IsPaid = 0,
                ProductIdRef = productId,
                ShippingIdRef = shippingId,
                
            };

            db.Shippings.Add(shipping);
            db.Payments.Add(payment);

            db.SaveChanges();

            return View("Success");
        }

        public IQueryable<Product> GetProducts()
        {
            var userId = User.Identity.GetUserId();
            // Mỗi khi tạo user đều tạo 1 cart tương ứng với user nên ko cần check null
            var shoppingCart = db.ShoppingCarts.SingleOrDefault(m => m.UserIdRef.Equals(userId));
            var cartProducts = db.CartProducts.Where(m => m.ShoppingCart_Id == shoppingCart.Id);
            var products = (from p in db.Products
                            join cp in cartProducts on p.Id equals cp.ProductIdRef
                            select p);
            return products;
        }
    }
}