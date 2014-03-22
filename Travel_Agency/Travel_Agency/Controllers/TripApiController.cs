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
        // GET api/tripapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tripapi/5
        public string Get(int id)
        {
            return "value";
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

        // PUT api/tripapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tripapi/5
        public void Delete(int id)
        {
        }
    }
}
