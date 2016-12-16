using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Mails
        public ActionResult Index()
        {
            var mails = db.Mails.Include(m => m.User);
            return View(mails.ToList());
        }

        // GET: Admin/Mails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail mail = db.Mails.Find(id);
            if (mail == null)
            {
                return HttpNotFound();
            }
            mail.User = db.Users.Find(mail.UserIdRef);
            return View(mail);
        }

        // GET: Admin/Mails/Create
        public ActionResult Create()
        {
            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/Mails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserIdRef,Title,Description,MailContent,CreateDate,IsSent")] Mail mail)
        {
            if (ModelState.IsValid)
            {
                mail.CreateDate = DateTime.Now.ToShortDateString();
                mail.User = db.Users.Find(mail.UserIdRef);
                db.Mails.Add(mail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email", mail.UserIdRef);
            return View(mail);
        }

        // GET: Admin/Mails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail mail = db.Mails.Find(id);
            if (mail == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email", mail.UserIdRef);
            return View(mail);
        }

        // POST: Admin/Mails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserIdRef,Title,Description,MailContent,CreateDate,IsSent")] Mail mail)
        {
            if (ModelState.IsValid)
            {
                mail.User = db.Users.Find(mail.UserIdRef);
                db.Entry(mail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserIdRef = new SelectList(db.Users, "Id", "Email", mail.UserIdRef);
            return View(mail);
        }

        // GET: Admin/Mails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail mail = db.Mails.Find(id);
            if (mail == null)
            {
                return HttpNotFound();
            }
            mail.User = db.Users.Find(mail.UserIdRef);
            return View(mail);
        }

        // POST: Admin/Mails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mail mail = db.Mails.Find(id);
            db.Mails.Remove(mail);
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
