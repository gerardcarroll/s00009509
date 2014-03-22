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

        public Leg AddLeg(Leg l)
        {
            _ctx.Entry(l).State = EntityState.Added;
            _ctx.SaveChanges();
            return l;
        }

        public IQueryable<Leg> GetLegsForTrip(int id)
        {
            return _ctx.Legs.Where(l => l.TripID == id).OrderBy(le => le.StartDate);
        }       
        
        public IQueryable<Guest> GetAllGuests()
        {
            return _ctx.Guests;
        }
        public ICollection<Guest> GetGuestsForLeg(int id)
        {
            return _ctx.Legs.FirstOrDefault(l => l.ID == id).Guests;
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