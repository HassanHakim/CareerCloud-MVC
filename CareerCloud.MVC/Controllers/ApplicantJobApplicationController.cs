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
    public class ApplicantJobApplicationController : Controller
    {
        ApplicantJobApplicationLogic _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantJobApplication
        //[Route("ApplicantJobApplication/Index")]
        //public ActionResult Index()
        //{
        //    var applicantJobApplication = db.ApplicantJobApplication.Include(a => a.ApplicantProfile).Include(a => a.CompanyJob);
        //    return View(applicantJobApplication.ToList());
        //}

        [Route("ApplicantJobApplication/Index/applicantId")]
        public ActionResult Index(Guid? applicantId)
        {

            var applicantJobApplication = db.ApplicantJobApplication.Where(a => (applicantId == null) ? true : a.Applicant == applicantId)
                                                            .Include(a => a.ApplicantProfile).Include(a => a.CompanyJob);
            
            return View(applicantJobApplication.ToList());
        }



        // GET: ApplicantJobApplication/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = db.ApplicantJobApplication.Find(id); // _logic.Get(id); 
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Id");
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id");
            return View();
        }

        // POST: ApplicantJobApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationDate,TimeStamp,Applicant,Job")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantJobApplicationPoco.Id = Guid.NewGuid();
                //db.ApplicantJobApplication.Add(applicantJobApplicationPoco);
                //db.SaveChanges();
                _logic.Add(new ApplicantJobApplicationPoco[] { applicantJobApplicationPoco });
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantJobApplicationPoco.Applicant);
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", applicantJobApplicationPoco.Job);
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = _logic.Get(id); // db.ApplicantJobApplication.Find(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantJobApplicationPoco.Applicant);
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", applicantJobApplicationPoco.Job);
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationDate,TimeStamp,Applicant,Job")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(applicantJobApplicationPoco).State = EntityState.Modified;
                //db.SaveChanges();

                _logic.Update(new ApplicantJobApplicationPoco[] { applicantJobApplicationPoco });
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Country", applicantJobApplicationPoco.Applicant);
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", applicantJobApplicationPoco.Job);
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco =  db.ApplicantJobApplication.Find(id); // _logic.Get(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco = db.ApplicantJobApplication.Find(id);
            db.ApplicantJobApplication.Remove(applicantJobApplicationPoco);
            db.SaveChanges();

            //_logic.Delete(new ApplicantJobApplicationPoco[] { applicantJobApplicationPoco });

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
