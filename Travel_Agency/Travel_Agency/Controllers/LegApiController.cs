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
        
        // POST api/legapi
        public HttpResponseMessage Post(Leg l)
        {
            bool complete = false;

            if (ModelState.IsValid)
            {
                if (CheckIfValid(l))
                {
                    _repo.AddLeg(l);
                    complete = CheckIsTripComplete(l);
                    _repo.UpdateTripComplete(l.TripID, complete);
                    var response = Request.CreateResponse<Leg>(HttpStatusCode.Created, l);
                    return response;
                }
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        private bool CheckIsTripComplete(Leg l)
        {
            Trip t = _repo.GetTripById(l.TripID);
            IQueryable<Leg> legs = _repo.GetLegsForTrip(l.TripID);

            List<DateTime> allLegDates = new List<DateTime>();
            foreach (Leg i in legs)
            {
                DateTime oldLegDate = i.StartDate.Date;
                while (oldLegDate <= i.FinishDate.Date)
                {
                    allLegDates.Add(oldLegDate);
                    oldLegDate = oldLegDate.AddDays(1).Date;
                }
            }
            DateTime tripDate = t.StartDate.Date;
            List<DateTime> tripDates = new List<DateTime>();
            while (tripDate <= t.FinishDate)
            {
                tripDates.Add(tripDate);
                tripDate = tripDate.AddDays(1).Date;
            }
            foreach (DateTime dt in tripDates)
            {
                if (!allLegDates.Contains(dt))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfValid(Leg l)
        {
            Trip t = _repo.GetTripById(l.TripID);
            IQueryable<Leg> legs = _repo.GetLegsForTrip(l.TripID);

            if (l.StartDate > l.FinishDate)
            {
                return false;
            }
            else if (l.StartDate.Date < t.StartDate.Date)
            {
                return false;
            }
            else if (l.FinishDate.Date > t.FinishDate.Date)
            {
                return false;
            }

            List<DateTime> usedDates = new List<DateTime>();
            foreach (Leg i in legs)
            {
                DateTime oldLegDate = i.StartDate.Date;
                while (oldLegDate <= i.FinishDate.Date)
                {
                    usedDates.Add(oldLegDate);
                    oldLegDate = oldLegDate.AddDays(1).Date;
                }                
            }

            DateTime newLegDate = l.StartDate.Date;
            List<DateTime> newDates = new List<DateTime>();
            while (newLegDate <= l.FinishDate.Date)
            {
                newDates.Add(newLegDate);
                newLegDate = newLegDate.AddDays(1).Date;
            }
            foreach (DateTime dt in newDates)
            {
                if (usedDates.Contains(dt))
                {
                    return false;
                }
            }
            return true;
        }
                
    }
}
