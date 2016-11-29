using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductPartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductParts
        public ActionResult Index()
        {
            var productParts = db.ProductParts.Include(p => p.Part).Include(p => p.Product);
            return View(productParts.ToList());
        }

        // GET: Admin/ProductParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPart productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return HttpNotFound();
            }
            return View(productPart);
        }

        // GET: Admin/ProductParts/Create
        public ActionResult Create()
        {
            ViewBag.PartIdRef = new SelectList(db.Parts, "Id", "Name");
            ViewBag.Product_Id = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/ProductParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartIdRef,Product_Id")] ProductPart productPart)
        {
            if (ModelState.IsValid)
            {
                db.ProductParts.Add(productPart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartIdRef = new SelectList(db.Parts, "Id", "Name", productPart.PartIdRef);
            ViewBag.Product_Id = new SelectList(db.Products, "Id", "Name", productPart.Product_Id);
            return View(productPart);
        }

        // GET: Admin/ProductParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPart productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartIdRef = new SelectList(db.Parts, "Id", "Name", productPart.PartIdRef);
            ViewBag.Product_Id = new SelectList(db.Products, "Id", "Name", productPart.Product_Id);
            return View(productPart);
        }

        // POST: Admin/ProductParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartIdRef,Product_Id")] ProductPart productPart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productPart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartIdRef = new SelectList(db.Parts, "Id", "Name", productPart.PartIdRef);
            ViewBag.Product_Id = new SelectList(db.Products, "Id", "Name", productPart.Product_Id);
            return View(productPart);
        }

        // GET: Admin/ProductParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPart productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return HttpNotFound();
            }
            return View(productPart);
        }

        // POST: Admin/ProductParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductPart productPart = db.ProductParts.Find(id);
            db.ProductParts.Remove(productPart);
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
