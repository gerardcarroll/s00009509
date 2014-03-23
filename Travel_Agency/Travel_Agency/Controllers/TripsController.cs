using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers
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
        
    }
}
