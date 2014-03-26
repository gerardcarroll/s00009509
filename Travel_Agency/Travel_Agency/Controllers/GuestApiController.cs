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
    public class GuestApiController : ApiController
    {
        private ITravelRepository _repo;

        public GuestApiController(ITravelRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public HttpResponseMessage Post(List<String> g)
        {
            Guest guest = _repo.GetGuestByName(g[0]);
            int legId = int.Parse(g[1]);
            if (guest != null)
            {
                if (!AlreadyOnLeg(guest, g[1]))
                {
                    _repo.AddGuestToLeg(guest, legId);
                    CheckIfTripViable(legId);

                    return Request.CreateResponse(HttpStatusCode.Accepted, "Guest Added!!");                    
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Guest is Already Booked On Leg!!");                    
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Data!!");
        }

        private void CheckIfTripViable(int legId)
        {
            //To determine if the trip is viable a guest can only count
            //towards the guest count if they are on two or more legs.
            //The number on two or more legs is counted/
            //If this is >= MinGuests then Trip is viable

            //However if the trip only has one leg from start to finish of the Trip
            //then the Min Guests is only accounted for in that leg

            List<Guest> guests = _repo.GetAllGuests();
            Leg leg = _repo.GetLegById(legId);
            Trip trip = _repo.GetTripById(leg.TripID);
            Int32 minGuests = _repo.GetMinGuestsForTrip(trip.ID);
            List<Int32> guestIds = new List<Int32>();
            int counter = 0;

            //Check if trip is complete
            if (trip.Complete)
            {
                //If trip has only one leg
                if (trip.Legs.Count == 1)
                {
                    //if min guests is ok
                    if (leg.Guests.Count >= trip.MinGuests)
                    {
                        //Update the trip to viable
                        _repo.UpdateTripViability(trip.ID, true);
                        return;
                    }
                }
            }

            foreach (Guest g in guests)
            {
                foreach (Leg l in trip.Legs)
                {
                    if (l.Guests.Contains(g))
                    {
                        guestIds.Add(g.ID);
                    }
                }

                if (guestIds.Contains(g.ID))
                {
                    if (guestIds.Count(gu => gu == g.ID) >= 2)
                    {
                        counter++;
                    }
                }
                if (counter >= minGuests)
                {
                    //Update the trip to viable
                    _repo.UpdateTripViability(trip.ID, true);
                    return;
                }
            }   
        }

        private bool AlreadyOnLeg(Guest g, string legId)
        {
            Leg l = _repo.GetLegById(int.Parse(legId));
            if (l.Guests.Contains(g))
            {
                return true;   
            }
            else
            {
                return false;
            }
        }
    }
}
