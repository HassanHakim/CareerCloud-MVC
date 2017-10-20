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
    public class CompanyDescriptionController : Controller
    {
        CompanyDescriptionLogic _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyDescription
        public ActionResult Index()
        {
            var companyDescription = db.CompanyDescription.Include(c => c.CompanyProfile).Include(c => c.SystemLanguageCode);
            return View(companyDescription.ToList());
        }

        [Route("CompanyDescription/Index/companyId")]
        public ActionResult Index(Guid companyId)
        {
            var companyDescription = db.CompanyDescription.Where(cd=>cd.Company==companyId).Include(c => c.CompanyProfile).Include(c => c.SystemLanguageCode);
            return View(companyDescription.ToList());
        }

        // GET: CompanyDescription/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescriptionPoco companyDescriptionPoco =  db.CompanyDescription.Find(id); // _logic.Get(id); 
            if (companyDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyDescriptionPoco);
        }

        // GET: CompanyDescription/Create
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite");
            ViewBag.LanguageId = new SelectList(db.SystemLanguageCode, "LanguageID", "NativeName");
            return View();
        }

        // POST: CompanyDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,CompanyDescription,TimeStamp,Company,LanguageId")] CompanyDescriptionPoco companyDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyDescriptionPoco.Id = Guid.NewGuid();
                //db.CompanyDescription.Add(companyDescriptionPoco);
                //db.SaveChanges();
                _logic.Add(new CompanyDescriptionPoco[] { companyDescriptionPoco });
                return RedirectToAction("Index");
            }

            ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyDescriptionPoco.Company);
            ViewBag.LanguageId = new SelectList(db.SystemLanguageCode, "LanguageID", "NativeName", companyDescriptionPoco.LanguageId);
            return View(companyDescriptionPoco);
        }

        // GET: CompanyDescription/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescriptionPoco companyDescriptionPoco = _logic.Get(id);  // db.CompanyDescription.Find(id);
            if (companyDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyDescriptionPoco.Company);
            ViewBag.LanguageId = new SelectList(db.SystemLanguageCode, "LanguageID", "NativeName", companyDescriptionPoco.LanguageId);
            return View(companyDescriptionPoco);
        }

        // POST: CompanyDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,CompanyDescription,TimeStamp,Company,LanguageId")] CompanyDescriptionPoco companyDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(companyDescriptionPoco).State = EntityState.Modified;
                //db.SaveChanges();
                _logic.Update(new CompanyDescriptionPoco[] { companyDescriptionPoco });
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyDescriptionPoco.Company);
            ViewBag.LanguageId = new SelectList(db.SystemLanguageCode, "LanguageID", "NativeName", companyDescriptionPoco.LanguageId);
            return View(companyDescriptionPoco);
        }

        // GET: CompanyDescription/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescriptionPoco companyDescriptionPoco = _logic.Get(id);  // db.CompanyDescription.Find(id);
            if (companyDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyDescriptionPoco);
        }

        // POST: CompanyDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyDescriptionPoco companyDescriptionPoco = _logic.Get(id);  // db.CompanyDescription.Find(id);
            //db.CompanyDescription.Remove(companyDescriptionPoco);
            //db.SaveChanges();
            _logic.Delete(new CompanyDescriptionPoco[] { companyDescriptionPoco });
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
