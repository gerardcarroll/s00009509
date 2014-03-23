using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travel_Agency.Models;
using Travel_Agency.DAL;

namespace Travel_Agency.Controllers
{
    public class TripApiController : ApiController
    {
        private ITravelRepository _repo;

        public TripApiController(ITravelRepository repo)
        {
            _repo = repo;
        }
        
        // POST api/tripapi
        public HttpResponseMessage Post(Trip trip)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTrip(trip);

                var response = Request.CreateResponse<Trip>(HttpStatusCode.Created, trip);
                return response;
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
                
    }
}
