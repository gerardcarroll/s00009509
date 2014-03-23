using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace Travel_Agency.DAL
{
    public class TravelRepository:ITravelRepository
    {
        private TravelContext _ctx;

        public TravelRepository()
        {
            _ctx = new TravelContext();            
        }

        public IQueryable<Trip> GetAllTrips()
        {
            return _ctx.Trips.OrderBy(t => t.StartDate);
        }

        public Trip GetTripById(int id)
        {
            return _ctx.Trips.FirstOrDefault(t => t.ID == id);
        }

        public String GetTripName(int id)
        {
            return _ctx.Trips.FirstOrDefault(t => t.ID == id).Name;
        }

        public Trip AddTrip(Trip t)
        {
            _ctx.Entry(t).State = EntityState.Added;
            _ctx.SaveChanges();
            return t;
        }

        public String UpdateTripComplete(int tid, bool c)
        {
            var q = _ctx.Trips.FirstOrDefault(t => t.ID == tid);
            try
            {
                q.Complete = c;
                _ctx.SaveChanges();
                return "ok";
            }
            catch (Exception)
            {
                return "error";                
            }
        }

        public String UpdateTripViability(int tid, bool v)
        {
            var q = _ctx.Trips.FirstOrDefault(t => t.ID == tid);
            try
            {
                q.Viable = v;
                _ctx.SaveChanges();
                return "ok";
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public Int32 GetMinGuestsForTrip(int id)
        {
            return _ctx.Trips.FirstOrDefault(t => t.ID == id).MinGuests;
        }

        public Leg AddLeg(Leg l)
        {
            _ctx.Entry(l).State = EntityState.Added;
            _ctx.SaveChanges();
            return l;
        }

        public Guest AddGuestToLeg(Guest g, int id)
        {
            _ctx.Legs.FirstOrDefault(l => l.ID == id).Guests.Add(g);
            _ctx.SaveChanges();
            return g;
        }

        public IQueryable<Leg> GetLegsForTrip(int id)
        {
            return _ctx.Legs.Where(l => l.TripID == id).OrderBy(le => le.StartDate);
        }       
        
        public List<string> GetAllGuestNames()
        {
            List<string> guests = new List<string>();
            var q = from g in _ctx.Guests
                    select g.FirstName;
            foreach (var g in q)
            {
                guests.Add(g);   
            }
            
            return guests;
        }

        public Guest GetGuestByName(string nme)
        {
            return _ctx.Guests.FirstOrDefault(g => g.FirstName == nme);
        }

        public List<Int32> GetAllGuestIDs()
        {
            List<Int32> guestIds = new List<Int32>();
            var q = _ctx.Guests;
            foreach (Guest g in q)
            {
                guestIds.Add(g.ID);
            }
            return guestIds;
        }
        public ICollection<Guest> GetGuestsForLeg(int id)
        {
            return _ctx.Legs.FirstOrDefault(l => l.ID == id).Guests;
        }

        public List<Guest> GetAllGuests()
        {
            return _ctx.Guests.ToList();
        }

        public Leg GetLegById(int id)
        {
            return _ctx.Legs.FirstOrDefault(l => l.ID == id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}