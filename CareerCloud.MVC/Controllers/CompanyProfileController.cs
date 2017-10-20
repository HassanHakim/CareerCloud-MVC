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
    public class CompanyProfileController : Controller
    {       

        CompanyProfileLogic _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyProfile
        [Route("CompanyProfile/Index")]
        public ActionResult Index()
        {
            return View(db.CompanyProfile.ToList());
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);  // _logic.Get(id); 
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                _logic.Add(new CompanyProfilePoco[] { companyProfilePoco });
                //db.CompanyProfile.Add(companyProfilePoco);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = _logic.Get(id); // db.CompanyProfile.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                _logic.Update(new CompanyProfilePoco[] { companyProfilePoco });
                //db.Entry(companyProfilePoco).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = _logic.Get(id);  // db.CompanyProfile.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyProfilePoco companyProfilePoco = _logic.Get(id);  // db.CompanyProfile.Find(id);
            _logic.Delete(new CompanyProfilePoco[] { companyProfilePoco });
            //db.CompanyProfile.Remove(companyProfilePoco);
            //db.SaveChanges();
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
