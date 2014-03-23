using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Travel_Agency.DAL;

namespace Travel_Agency.Controllers
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
            return View(_repo.GetAllTrips());
        }

        public ActionResult Create()
        {
            return PartialView("_AddTrip");
        }
        
        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}