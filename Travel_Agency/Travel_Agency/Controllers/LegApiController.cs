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
                    //Add the leg
                    _repo.AddLeg(l);
                    complete = CheckIsTripComplete(l);
                    //Update if complete
                    if (complete)
                    {
                        _repo.UpdateTripComplete(l.TripID, complete);
                    }                    
                    
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Leg Created!!");
                }

                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Dates Invalid!!");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Data!!");
        }

        private bool CheckIsTripComplete(Leg l)
        {
            Trip t = _repo.GetTripById(l.TripID);
            IQueryable<Leg> legs = _repo.GetLegsForTrip(l.TripID);

            //Get All Leg Dates for this Trip
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
            //Get all valid trip dates
            while (tripDate <= t.FinishDate)
            {
                tripDates.Add(tripDate);
                tripDate = tripDate.AddDays(1).Date;
            }
            
            foreach (DateTime dt in tripDates)
            {
                //If there is a date in trip not covered by any of the legs
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

            //Leg StartDate after Leg Finish Date
            if (l.StartDate > l.FinishDate)
            {
                return false;
            }
            //Leg Start Date Before Trip Start Date
            else if (l.StartDate.Date < t.StartDate.Date)
            {
                return false;
            }
            //Leh Finish Date After Trip Finish Date
            else if (l.FinishDate.Date > t.FinishDate.Date)
            {
                return false;
            }

            //Get the all the dates already in the other legs
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

            //Get all the dates of the new leg
            DateTime newLegDate = l.StartDate.Date;
            List<DateTime> newDates = new List<DateTime>();
            while (newLegDate <= l.FinishDate.Date)
            {
                newDates.Add(newLegDate);
                newLegDate = newLegDate.AddDays(1).Date;
            }

            //Check if any clash
            foreach (DateTime dt in newDates)
            {
                if (usedDates.Contains(dt))
                {
                    //If clash return false(leg invalid)
                    return false;
                }
            }
            //Leg Valid
            return true;
        }
                
    }
}
