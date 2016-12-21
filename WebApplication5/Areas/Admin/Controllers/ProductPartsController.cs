using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using WebApplication5.Models;

namespace WebApplication5.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductPartsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductParts
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var productParts = from product in db.Products
                join
                    productPart in db.ProductParts on product.Id equals productPart.ProductIdRef
                join
                    part in db.Parts on productPart.PartIdRef equals part.Id
                where product.Id == id
                select part;
            ViewBag.ProductPartAvails = db.Parts.ToList().Except(productParts);

            return View(productParts.ToList());
        }

        // GET: Admin/ProductParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return HttpNotFound();
            }
            return View(productPart);
        }

        // GET: Admin/ProductParts/Create
        public ActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title");
            return View();
        }

        // POST: Admin/ProductParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Name,Description,Origin,Manufacturer,CreateDate,DocumentIdRef,ImageLink,ProductId")] Part part)
        {
            if (ModelState.IsValid)
            {
                // lấy dữ liệu từ form ra chuyển đổi từ string qua int
                var productId = int.Parse(Request.Form["ProductId"]);

                part.Id = 1;
                var parts = db.Parts.OrderBy(m => m.Id);
                if (parts.Any())
                {
                    part.Id = parts.ToList().Last().Id + 1;
                }

                part.CreateDate = DateTime.Now.ToShortDateString();
                db.Parts.Add(part);

                var productPart = new ProductPart
                {
                    PartIdRef = part.Id,
                    ProductIdRef = productId
                };

                db.ProductParts.Add(productPart);
                db.SaveChanges();
                return RedirectToAction("Index", new {id = productId});
            }

            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title");
            return View(part);
        }

        // GET: Admin/ProductParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartIdRef = new SelectList(db.Parts, "Id", "Name", productPart.PartIdRef);
            ViewBag.Product_Id = new SelectList(db.Products, "Id", "Name", productPart.ProductIdRef);
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
            ViewBag.Product_Id = new SelectList(db.Products, "Id", "Name", productPart.ProductIdRef);
            return View(productPart);
        }

        // GET: Admin/ProductParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productPart = db.ProductParts.Find(id);
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
            var productPart = db.ProductParts.Find(id);
            db.ProductParts.Remove(productPart);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }


        public JsonResult AddPartAjax()
        {            
                        
            if (string.IsNullOrEmpty(Request.Form["addedParts[]"]))
            {
                return null;
            }
            int productId = int.Parse(Request.Form["productId"]);
            string[] splitedParts = Request.Form["addedParts[]"].Split(',');          

            foreach (var partStr in splitedParts)
            {                
                var partId = int.Parse(partStr.Split('_')[1]);
                db.ProductParts.Add(new ProductPart
                {
                    PartIdRef = partId,
                    ProductIdRef = productId
                });
            }
            db.SaveChanges();

            return Json(new {msg = "done"});
        }

        public JsonResult DeletePartAjax()
        {

            if (string.IsNullOrEmpty(Request.Form["deleteParts[]"]))
            {
                return null;
            }
            int productId = int.Parse(Request.Form["productId"]);
            string[] splitedParts = Request.Form["deleteParts[]"].Split(',');

            foreach (var partStr in splitedParts)
            {
                var partId = int.Parse(partStr.Split('_')[1]);
                var partProduct =
                    db.ProductParts.SingleOrDefault(m => m.PartIdRef == partId && m.ProductIdRef == productId);
                db.ProductParts.Remove(partProduct);
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
