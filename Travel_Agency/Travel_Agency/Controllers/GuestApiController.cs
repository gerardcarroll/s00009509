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
            HttpResponseMessage response;

            Guest guest = _repo.GetGuestByName(g[0]);
            int legId = int.Parse(g[1]);
            if (guest != null)
            {
                if (!AlreadyOnLeg(guest, g[1]))
                {
                    _repo.AddGuestToLeg(guest, legId);
                    CheckIfTripViable(legId);
                    
                    return response = new HttpResponseMessage(HttpStatusCode.Accepted);                    
                }
                else
                {
                    return response = new HttpResponseMessage(HttpStatusCode.Conflict);                    
                }
            }            
            return response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private void CheckIfTripViable(int legId)
        {
            List<Guest> guests = _repo.GetAllGuests();
            Leg leg = _repo.GetLegById(legId);
            Trip trip = _repo.GetTripById(leg.TripID);
            Int32 minGuests = _repo.GetMinGuestsForTrip(trip.ID);
            List<Int32> guestIds = new List<Int32>();
            int counter = 0;

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
