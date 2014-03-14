using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace s00009509_Travel.Controllers
{
    public class LegsController : Controller
    {
        private ITravelRepository _repo;

        public LegsController(ITravelRepository repo)
        {
            _repo = repo;
        }

        // GET api/legs/5
        public ActionResult GetLegs(int id)
        {
            return PartialView("_TripLeg", _repo.GetLegsForTrip(id));
        }

    }
}
