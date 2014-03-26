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
                if (CheckDates(trip))
                {
                    _repo.AddTrip(trip);

                    return Request.CreateResponse(HttpStatusCode.Accepted, "Trip Created!!");                    
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Invalid Dates!!");                
                }
                
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Data!!");
        }
        private bool CheckDates(Trip t)
        {
            if (t.StartDate > t.FinishDate)
            {
                return false;
            }
            return true;
        }
                
    }
}
