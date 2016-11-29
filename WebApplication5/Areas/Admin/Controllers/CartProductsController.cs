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
        public ActionResult Index()
        {
            var cartProducts = db.CartProducts.Include(c => c.Product).Include(c => c.ShoppingCart);
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
        public ActionResult Create()
        {
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name");
            ViewBag.ShoppingCart_Id = new SelectList(db.ShoppingCarts, "Id", "UserIdRef");
            return View();
        }

        // POST: Admin/CartProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductIdRef,ShoppingCart_Id")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                db.CartProducts.Add(cartProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name", cartProduct.ProductIdRef);
            ViewBag.ShoppingCart_Id = new SelectList(db.ShoppingCarts, "Id", "UserIdRef", cartProduct.ShoppingCart_Id);
            return View(cartProduct);
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
            ViewBag.ShoppingCart_Id = new SelectList(db.ShoppingCarts, "Id", "UserIdRef", cartProduct.ShoppingCart_Id);
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
            ViewBag.ShoppingCart_Id = new SelectList(db.ShoppingCarts, "Id", "UserIdRef", cartProduct.ShoppingCart_Id);
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
