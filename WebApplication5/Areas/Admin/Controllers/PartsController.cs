using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Parts
        public ActionResult Index()
        {
            var parts = db.Parts.Include(p => p.Document);
            return View(parts.ToList());
        }

        // GET: Admin/Parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // GET: Admin/Parts/Create
        public ActionResult Create()
        {
            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title");
            return View();
        }

        // POST: Admin/Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Origin,Manufacturer,CreateDate,DocumentIdRef")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title", part.DocumentIdRef);
            return View(part);
        }

        // GET: Admin/Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title", part.DocumentIdRef);
            return View(part);
        }

        // POST: Admin/Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Origin,Manufacturer,CreateDate,DocumentIdRef")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentIdRef = new SelectList(db.Documents, "Id", "Title", part.DocumentIdRef);
            return View(part);
        }

        // GET: Admin/Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // POST: Admin/Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = db.Parts.Find(id);
            db.Parts.Remove(part);
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
