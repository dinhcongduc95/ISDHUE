using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CartProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CartProducts
        public ActionResult Index(int id)
        {
            var cartProducts = from product in db.Products
                               join
                                   cartProduct in db.CartProducts on product.Id equals cartProduct.ProductIdRef                               
                               where cartProduct.ShoppingCartIdRef == id
                               select product;
            ViewBag.CartProductAvails = db.Products.ToList().Except(cartProducts);
            ViewBag.CartId = id;
            return View(cartProducts.ToList());
        }

        // GET: Admin/CartProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            return View(cartProduct);
        }

        // GET: Admin/CartProducts/Create
        public ActionResult Create(int id)
        {
            ViewBag.CartId = id;
            ViewBag.CategoryIdRef = new SelectList(db.Categories, "Id", "Code");
            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title");
            return View();
        }

        // POST: Admin/CartProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductIdRef,ShoppingCartIdRef,CartId")] Product product)
        {
            var cartId = int.Parse(Request.Form["CartId"]);
            if (ModelState.IsValid)
            {
                var newProductId = db.Products.OrderBy(m => m.Id).Last().Id + 1;
                product.Id = newProductId;
                db.Products.Add(product);
                db.CartProducts.Add(new CartProduct
                {
                    ProductIdRef = newProductId,
                    ShoppingCartIdRef = cartId
                });
                db.SaveChanges();
                return RedirectToAction("Index", "CartProducts", new { id = cartId });
            }

            ViewBag.CategoryIdRef = new SelectList(db.Categories, "Id", "Code");
            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title");
            return View();
        }

        // GET: Admin/CartProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name", cartProduct.ProductIdRef);
            ViewBag.ShoppingCart_Id = new SelectList(db.ShoppingCarts, "Id", "UserIdRef", cartProduct.ShoppingCartIdRef);
            return View(cartProduct);
        }

        // POST: Admin/CartProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductIdRef,ShoppingCart_Id")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name", cartProduct.ProductIdRef);
            ViewBag.ShoppingCart_Id = new SelectList(db.ShoppingCarts, "Id", "UserIdRef", cartProduct.ShoppingCartIdRef);
            return View(cartProduct);
        }

        // GET: Admin/CartProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            return View(cartProduct);
        }

        // POST: Admin/CartProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartProduct cartProduct = db.CartProducts.Find(id);
            db.CartProducts.Remove(cartProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult AddProductAjax()
        {

            if (string.IsNullOrEmpty(Request.Form["addedProducts[]"]))
            {
                return null;
            }
            int cartId = int.Parse(Request.Form["cartId"]);
            string[] splitedProducts = Request.Form["addedProducts[]"].Split(',');

            foreach (var partStr in splitedProducts)
            {
                var productId = int.Parse(partStr.Split('_')[1]);
                db.CartProducts.Add(new CartProduct
                {
                    ProductIdRef = productId,
                    ShoppingCartIdRef = cartId                    
                });
            }
            db.SaveChanges();

            return Json(new { msg = "done" });
        }

        public JsonResult DeleteProductAjax()
        {

            if (string.IsNullOrEmpty(Request.Form["deleteProducts[]"]))
            {
                return null;
            }
            int cartId = int.Parse(Request.Form["cartId"]);
            string[] splitedProducts = Request.Form["deleteProducts[]"].Split(',');

            foreach (var productStr in splitedProducts)
            {
                var productId = int.Parse(productStr.Split('_')[1]);
                var cartProduct =
                    db.CartProducts.SingleOrDefault(m => m.ProductIdRef == productId && m.ShoppingCartIdRef == cartId);
                db.CartProducts.Remove(cartProduct);
            }
            db.SaveChanges();

            return Json(new { msg = "done" });
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
