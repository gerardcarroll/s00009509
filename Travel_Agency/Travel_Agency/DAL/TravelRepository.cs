using System;
using System.Collections.Generic;
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