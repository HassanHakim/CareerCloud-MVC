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
    public class CompanyJobEducationController : Controller
    {
        CompanyJobEducationLogic _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobEducation
        //[Route("CompanyJobEducation/Index")]
        //public ActionResult Index()
        //{
        //    var companyJobEducation = db.CompanyJobEducation.Include(c => c.CompanyJob);
        //    return View(companyJobEducation.ToList());
        //}

        [Route("CompanyJobEducation/Index/jobId")]
        public ActionResult Index(Guid? jobId)
        {
            var companyJobEducation = db.CompanyJobEducation.Include(c => c.CompanyJob);
            if (jobId != null)
                 companyJobEducation = companyJobEducation.Where(je=>je.Job==jobId);

            return View(companyJobEducation.ToList());
        }

        // GET: CompanyJobEducation/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco =  db.CompanyJobEducation.Find(id); // _logic.Get(id); // 
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id");
            return View();
        }

        // POST: CompanyJobEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeStamp,Job,Major,Importance")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobEducationPoco.Id = Guid.NewGuid();
                //db.CompanyJobEducation.Add(companyJobEducationPoco);
                //db.SaveChanges();
                _logic.Add(new CompanyJobEducationPoco[] { companyJobEducationPoco });
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = _logic.Get(id);  // db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeStamp,Job,Major,Importance")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(companyJobEducationPoco).State = EntityState.Modified;
                //db.SaveChanges();
                _logic.Update(new CompanyJobEducationPoco[] { companyJobEducationPoco });
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = _logic.Get(id);//  db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobEducationPoco companyJobEducationPoco = _logic.Get(id);  // db.CompanyJobEducation.Find(id);
            //db.CompanyJobEducation.Remove(companyJobEducationPoco);
            //db.SaveChanges();
             _logic.Delete(new CompanyJobEducationPoco[] { companyJobEducationPoco });
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
