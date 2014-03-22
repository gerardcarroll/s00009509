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
    public class LegApiController : ApiController
    {
         private ITravelRepository _repo;

        public LegApiController(ITravelRepository repo)
        {
            _repo = repo;
        }

        // GET api/legapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/legapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/legapi
        public HttpResponseMessage Post(Leg l)
        {
            if (ModelState.IsValid)
            {
                _repo.AddLeg(l);

                var response = Request.CreateResponse<Leg>(HttpStatusCode.Created, l);
                return response;
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT api/legapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/legapi/5
        public void Delete(int id)
        {
        }
    }
}
