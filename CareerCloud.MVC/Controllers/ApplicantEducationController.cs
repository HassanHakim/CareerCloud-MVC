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
    public class ApplicantEducationController : Controller
    {

        ApplicantEducationLogic _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantEducation
        [Route("ApplicantEducation/Index")]
        public ActionResult Index()
        {
            var applicantEducation = db.ApplicantEducation.Include(a => a.ApplicantProfile);
            return View(applicantEducation.ToList());
        }

        [Route("ApplicantEducation/Index/applicantId")]
        public ActionResult Index(Guid applicantId)
        {
            var applicantEducation = db.ApplicantEducation.Where(ae=>ae.Applicant== applicantId).Include(a => a.ApplicantProfile);
            return View(applicantEducation.ToList());
        }

        // GET: ApplicantEducation/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco =  db.ApplicantEducation.Find(id); // _logic.Get(id); 
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country");
            return View();
        }

        // POST: ApplicantEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CertificateDiploma,StartDate,CompletionDate,CompletionPercent,TimeStamp,Applicant,Major")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantEducationPoco.Id = Guid.NewGuid();
                //db.ApplicantEducation.Add(applicantEducationPoco);
                //db.SaveChanges();
                _logic.Add(new ApplicantEducationPoco[] { applicantEducationPoco });
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantEducationPoco.Applicant);
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = _logic.Get(id); // db.ApplicantEducation.Find(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantEducationPoco.Applicant);
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CertificateDiploma,StartDate,CompletionDate,CompletionPercent,TimeStamp,Applicant,Major")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(applicantEducationPoco).State = EntityState.Modified;
                //db.SaveChanges();
                _logic.Update(new ApplicantEducationPoco[] { applicantEducationPoco });
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantEducationPoco.Applicant);
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = _logic.Get(id); // db.ApplicantEducation.Find(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantEducationPoco applicantEducationPoco = _logic.Get(id); // db.ApplicantEducation.Find(id);
            //db.ApplicantEducation.Remove(applicantEducationPoco);
            //db.SaveChanges();
            _logic.Delete(new ApplicantEducationPoco[] { applicantEducationPoco });
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
