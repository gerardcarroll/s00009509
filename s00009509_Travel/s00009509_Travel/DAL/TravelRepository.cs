using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using s00009509_Travel.DAL;
using s00009509_Travel.Models;

namespace s00009509_Travel.DAL
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
            return _ctx.Trips.OrderBy(t => t.Name);
        }

        public IQueryable<Leg> GetLegsForTrip(int id)
        {
            return _ctx.Legs.Where(l => l.TripID == id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}