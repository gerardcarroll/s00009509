using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers
{
    public class GuestController : ApiController
    {
        private ITravelRepository _repo;

        public GuestController(ITravelRepository repo)
        {
            _repo = repo;
        }
    }
}
