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
    public class SystemCountryCodeController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: SystemCountryCode
        public ActionResult Index()
        {
            return View(db.SystemCountryCode.ToList());
        }

        // GET: SystemCountryCode/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCountryCodePoco systemCountryCodePoco = db.SystemCountryCode.Find(id);
            if (systemCountryCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemCountryCodePoco);
        }

        // GET: SystemCountryCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemCountryCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name")] SystemCountryCodePoco systemCountryCodePoco)
        {
            if (ModelState.IsValid)
            {
                db.SystemCountryCode.Add(systemCountryCodePoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemCountryCodePoco);
        }

        // GET: SystemCountryCode/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCountryCodePoco systemCountryCodePoco = db.SystemCountryCode.Find(id);
            if (systemCountryCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemCountryCodePoco);
        }

        // POST: SystemCountryCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name")] SystemCountryCodePoco systemCountryCodePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemCountryCodePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemCountryCodePoco);
        }

        // GET: SystemCountryCode/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCountryCodePoco systemCountryCodePoco = db.SystemCountryCode.Find(id);
            if (systemCountryCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemCountryCodePoco);
        }

        // POST: SystemCountryCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SystemCountryCodePoco systemCountryCodePoco = db.SystemCountryCode.Find(id);
            db.SystemCountryCode.Remove(systemCountryCodePoco);
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
