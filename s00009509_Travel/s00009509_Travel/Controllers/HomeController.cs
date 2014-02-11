using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using s00009509_Travel.DAL;

namespace s00009509_Travel.Controllers
{    
    public class HomeController : Controller
    {
        TravelContext db = new TravelContext();
        public ActionResult Index()
        {
            //var q = db.Trips.Find(1);
            //string name = q.Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}