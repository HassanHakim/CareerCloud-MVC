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
    public class ApplicantWorkHistoryController : Controller
    {
        ApplicantWorkHistoryLogic _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantWorkHistory
        public ActionResult Index()
        {
            var applicantWorkHistory = db.ApplicantWorkHistory.Include(a => a.ApplicantProfile).Include(a => a.SystemCountryCode);
            return View(applicantWorkHistory.ToList());
        }

        [Route("ApplicantWorkHistory/Index/applicantId")]
        public ActionResult Index(Guid applicantId)
        {
            var applicantWorkHistory = db.ApplicantWorkHistory.Where(e => e.Applicant == applicantId).Include(a => a.ApplicantProfile).Include(a => a.SystemCountryCode);
            return View(applicantWorkHistory.ToList());
        }
        // GET: ApplicantWorkHistory/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = db.ApplicantWorkHistory.Find(id); // _logic.Get(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country");
            ViewBag.CountryCode = new SelectList(db.SystemCountryCode, "Code", "Name");
            return View();
        }

        // POST: ApplicantWorkHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,CountryCode,JobTitle,JobDescription,StartMonth,StartYear,EndMonth,EndYear,TimeStamp,Applicant,Location")] ApplicantWorkHistoryPoco applicantWorkHistoryPoco)
        {
            if (ModelState.IsValid)
            {
                applicantWorkHistoryPoco.Id = Guid.NewGuid();
                //db.ApplicantWorkHistory.Add(applicantWorkHistoryPoco);
                //db.SaveChanges();
                _logic.Add(new ApplicantWorkHistoryPoco[]{ applicantWorkHistoryPoco});
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantWorkHistoryPoco.Applicant);
            ViewBag.CountryCode = new SelectList(db.SystemCountryCode, "Code", "Name", applicantWorkHistoryPoco.CountryCode);
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = _logic.Get(id); // db.ApplicantWorkHistory.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantWorkHistoryPoco.Applicant);
            ViewBag.CountryCode = new SelectList(db.SystemCountryCode, "Code", "Name", applicantWorkHistoryPoco.CountryCode);
            return View(applicantWorkHistoryPoco);
        }

        // POST: ApplicantWorkHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,CountryCode,JobTitle,JobDescription,StartMonth,StartYear,EndMonth,EndYear,TimeStamp,Applicant,Location")] ApplicantWorkHistoryPoco applicantWorkHistoryPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(applicantWorkHistoryPoco).State = EntityState.Modified;
                //db.SaveChanges();
                _logic.Update(new ApplicantWorkHistoryPoco[] { applicantWorkHistoryPoco });
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantWorkHistoryPoco.Applicant);
            ViewBag.CountryCode = new SelectList(db.SystemCountryCode, "Code", "Name", applicantWorkHistoryPoco.CountryCode);
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = _logic.Get(id); //db.ApplicantWorkHistory.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantWorkHistoryPoco);
        }

        // POST: ApplicantWorkHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = _logic.Get(id);// db.ApplicantWorkHistory.Find(id);
            //db.ApplicantWorkHistory.Remove(applicantWorkHistoryPoco);
            //db.SaveChanges();
            _logic.Delete(new ApplicantWorkHistoryPoco[] { applicantWorkHistoryPoco });
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
