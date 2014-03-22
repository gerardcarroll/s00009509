using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace s00009509_Travel.Controllers
{
    public class TripsController : Controller
    {
        private ITravelRepository _repo;

        public TripsController(ITravelRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_CreateTrip");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateTrip(Trip trip)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTrip(trip);
                return RedirectToAction("Index");
            }
            // if not valid, re-send View with already entered data
            return PartialView("_CreateTrip", trip);
        }
    }
}
