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
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantResumeController : Controller
    {
        ApplicantResumeLogic _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));

        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantResume
        public ActionResult Index()
        {
            var applicantResume = db.ApplicantResume.Include(a => a.ApplicantProfile);
            return View(applicantResume.ToList());
        }

        [Route("ApplicantResume/Index/applicantId")]
        public ActionResult Index(Guid applicantId)
        {
            var applicantResume = db.ApplicantResume.Where(e => e.Applicant == applicantId).Include(a => a.ApplicantProfile);
            return View(applicantResume.ToList());
        }

        // GET: ApplicantResume/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantResumePoco applicantResumePoco = _logic.Get(id); //db.ApplicantResume.Find(id);
            if (applicantResumePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country");
            return View();
        }

        // POST: ApplicantResume/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Resume,LastUpdated")] ApplicantResumePoco applicantResumePoco)
        {
            if (ModelState.IsValid)
            {
                applicantResumePoco.Id = Guid.NewGuid();
                //db.ApplicantResume.Add(applicantResumePoco);
                //db.SaveChanges();
                _logic.Add(new ApplicantResumePoco[]{ applicantResumePoco});
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantResumePoco.Applicant);
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantResumePoco applicantResumePoco = _logic.Get(id); // db.ApplicantResume.Find(id);
            if (applicantResumePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantResumePoco.Applicant);
            return View(applicantResumePoco);
        }

        // POST: ApplicantResume/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Resume,LastUpdated")] ApplicantResumePoco applicantResumePoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(applicantResumePoco).State = EntityState.Modified;
                //db.SaveChanges();
                _logic.Update(new ApplicantResumePoco[] { applicantResumePoco });
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantResumePoco.Applicant);
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantResumePoco applicantResumePoco = _logic.Get(id); // db.ApplicantResume.Find(id);
            if (applicantResumePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantResumePoco);
        }

        // POST: ApplicantResume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantResumePoco applicantResumePoco = _logic.Get(id); // db.ApplicantResume.Find(id);
            //db.ApplicantResume.Remove(applicantResumePoco);
            //db.SaveChanges();
            _logic.Delete(new ApplicantResumePoco[] { applicantResumePoco });
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
