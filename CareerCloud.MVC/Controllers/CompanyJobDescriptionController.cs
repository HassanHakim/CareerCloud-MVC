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
    public class CompanyJobDescriptionController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobDescription
        public ActionResult Index()
        {
            var companyJobDescription = db.CompanyJobDescription.Include(c => c.CompanyJob);
            return View(companyJobDescription.ToList());
        }
        [Route("CompanyJobDescription/Index/jobId")]
        public ActionResult Index(Guid jobId)
        {
            var companyJobDescription = db.CompanyJobDescription.Where(jd=>jd.Job==jobId).Include(c => c.CompanyJob);
            return View(companyJobDescription.ToList());
        }

        // GET: CompanyJobDescription/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescription.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id");
            return View();
        }

        // POST: CompanyJobDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobName,JobDescriptions,TimeStamp,Job")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobDescriptionPoco.Id = Guid.NewGuid();
                db.CompanyJobDescription.Add(companyJobDescriptionPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobDescriptionPoco.Job);
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescription.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobDescriptionPoco.Job);
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobName,JobDescriptions,TimeStamp,Job")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobDescriptionPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobDescriptionPoco.Job);
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescription.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescription.Find(id);
            db.CompanyJobDescription.Remove(companyJobDescriptionPoco);
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
