using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerCloud.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Career Cloud";

            return View();
        }

       
        public ActionResult Contact()
        {
            ViewBag.Message = "Career Cloud contacts";

            return View();
        }
    }
}