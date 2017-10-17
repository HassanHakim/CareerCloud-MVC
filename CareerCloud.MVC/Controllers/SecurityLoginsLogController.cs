using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class SecurityLoginsLogController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityLoginsLog
        public ActionResult Index()
        {
            var securityLoginsLog = db.SecurityLoginsLog.Include(s => s.SecurityLogin);
            return View(securityLoginsLog.ToList());
        }

        // GET: SecurityLoginsLog/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsLogPoco securityLoginsLogPoco = db.SecurityLoginsLog.Find(id);
            if (securityLoginsLogPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsLogPoco);
        }

        // GET: SecurityLoginsLog/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress");
            return View();
        }

        // POST: SecurityLoginsLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SourceIP,LogonDate,IsSuccesful,Login")] SecurityLoginsLogPoco securityLoginsLogPoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginsLogPoco.Id = Guid.NewGuid();
                db.SecurityLoginsLog.Add(securityLoginsLogPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress", securityLoginsLogPoco.Login);
            return View(securityLoginsLogPoco);
        }

        // GET: SecurityLoginsLog/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsLogPoco securityLoginsLogPoco = db.SecurityLoginsLog.Find(id);
            if (securityLoginsLogPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress", securityLoginsLogPoco.Login);
            return View(securityLoginsLogPoco);
        }

        // POST: SecurityLoginsLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SourceIP,LogonDate,IsSuccesful,Login")] SecurityLoginsLogPoco securityLoginsLogPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityLoginsLogPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress", securityLoginsLogPoco.Login);
            return View(securityLoginsLogPoco);
        }

        // GET: SecurityLoginsLog/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsLogPoco securityLoginsLogPoco = db.SecurityLoginsLog.Find(id);
            if (securityLoginsLogPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsLogPoco);
        }

        // POST: SecurityLoginsLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginsLogPoco securityLoginsLogPoco = db.SecurityLoginsLog.Find(id);
            db.SecurityLoginsLog.Remove(securityLoginsLogPoco);
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
