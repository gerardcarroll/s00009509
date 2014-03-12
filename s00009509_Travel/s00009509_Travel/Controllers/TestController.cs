using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using s00009509_Travel.DAL;
using s00009509_Travel.Models;

namespace s00009509_Travel.Controllers
{
    public class TestController : ApiController
    {
        private ITravelRepository _repo;

        public TestController(ITravelRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _repo.GetAllTrips();
        }
    }
}
