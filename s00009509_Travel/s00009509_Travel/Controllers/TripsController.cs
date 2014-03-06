﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using s00009509_Travel.DAL;
using s00009509_Travel.Models;

namespace s00009509_Travel.Controllers
{
    public class TripsController : ApiController
    {
        private ITravelRepository _repo;

        public TripsController(ITravelRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Trip> GetTrips()
        {
            return _repo.GetAllTrips();
        }
    }
}
