using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.User).Include(p => p.Product).Include(p => p.Shipping);
            return View(payments.ToList());
        }

        // GET: Admin/Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Admin/Payments/Create
        public ActionResult Create()
        {
            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email");
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name");
            ViewBag.ShippingIdRef = new SelectList(db.Shippings, "Id", "Name");
            return View();
        }

        // POST: Admin/Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserIdRef,ProductIdRef,ShippingIdRef,Amount,Currency,IsPaid")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email", payment.UserIdRef);
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name", payment.ProductIdRef);
            ViewBag.ShippingIdRef = new SelectList(db.Shippings, "Id", "Name", payment.ShippingIdRef);
            return View(payment);
        }

        // GET: Admin/Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email", payment.UserIdRef);
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name", payment.ProductIdRef);
            ViewBag.ShippingIdRef = new SelectList(db.Shippings, "Id", "Name", payment.ShippingIdRef);
            return View(payment);
        }

        // POST: Admin/Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserIdRef,ProductIdRef,ShippingIdRef,Amount,Currency,IsPaid")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email", payment.UserIdRef);
            ViewBag.ProductIdRef = new SelectList(db.Products, "Id", "Name", payment.ProductIdRef);
            ViewBag.ShippingIdRef = new SelectList(db.Shippings, "Id", "Name", payment.ShippingIdRef);
            return View(payment);
        }

        // GET: Admin/Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Admin/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
