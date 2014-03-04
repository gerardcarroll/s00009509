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
        private ITravelRepository _repo;

        public HomeController(ITravelRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            int i = 0;
            i = _repo.GetAllTrips().Count();
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

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}