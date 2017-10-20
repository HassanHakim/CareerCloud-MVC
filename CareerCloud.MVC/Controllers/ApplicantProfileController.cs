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
    public class ApplicantProfileController : Controller
    {
        ApplicantProfileLogic _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
        private CareerCloudContext db = new CareerCloudContext();      
        

        // GET: ApplicantProfile
        
        public ActionResult Index()
        {
            var applicantProfile = db.ApplicantProfile.Include(a => a.SecurityLogin).Include(a => a.SystemCountryCode);
            return View(applicantProfile);
            //return View(_logic.GetAll());
        }

        // GET: ApplicantProfile/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = _logic.Get(id);//db.ApplicantProfile.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress");
            ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name");
            return View();
        }

        // POST: ApplicantProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CurrentSalary,CurrentRate,Country,Province,Street,City,PostalCode,TimeStamp,Login,Currency")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                applicantProfilePoco.Id = Guid.NewGuid();
                //db.ApplicantProfile.Add(applicantProfilePoco);
                //db.SaveChanges();
                _logic.Add(new ApplicantProfilePoco[] { applicantProfilePoco });
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = _logic.Get(id);// db.ApplicantProfile.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CurrentSalary,CurrentRate,Country,Province,Street,City,PostalCode,TimeStamp,Login,Currency")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(applicantProfilePoco).State = EntityState.Modified;
                //db.SaveChanges();
                _logic.Update(new ApplicantProfilePoco[] { applicantProfilePoco });
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "EmailAddress", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = _logic.Get(id);// db.ApplicantProfile.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantProfilePoco applicantProfilePoco = _logic.Get(id);//db.ApplicantProfile.Find(id);
            //db.ApplicantProfile.Remove(applicantProfilePoco);
            //db.SaveChanges();
            _logic.Delete(new ApplicantProfilePoco[] { applicantProfilePoco });
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
