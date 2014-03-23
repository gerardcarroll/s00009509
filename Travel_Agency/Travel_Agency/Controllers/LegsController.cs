using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers
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
            ViewBag.tripname = _repo.GetTripName(id);
            ViewBag.tripId = id;            
            return PartialView("_TripLeg", _repo.GetLegsForTrip(id));
        }        

        public ActionResult GetDetails(int legid)
        {
            return PartialView("_LegDetails", _repo.GetLegById(legid));
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.TripID = id; 
            return PartialView("_CreateLeg");
        }

    }
}
