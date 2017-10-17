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
    public class SystemLanguageCodeController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: SystemLanguageCode
        public ActionResult Index()
        {
            return View(db.SystemLanguageCode.ToList());
        }

        // GET: SystemLanguageCode/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCode.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemLanguageCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageID,NativeName,Name")] SystemLanguageCodePoco systemLanguageCodePoco)
        {
            if (ModelState.IsValid)
            {
                db.SystemLanguageCode.Add(systemLanguageCodePoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCode/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCode.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // POST: SystemLanguageCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageID,NativeName,Name")] SystemLanguageCodePoco systemLanguageCodePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemLanguageCodePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCode/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCode.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // POST: SystemLanguageCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCode.Find(id);
            db.SystemLanguageCode.Remove(systemLanguageCodePoco);
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
