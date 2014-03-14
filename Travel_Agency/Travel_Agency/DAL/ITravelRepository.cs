using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Agency.Models;

namespace Travel_Agency.DAL
{
    public interface ITravelRepository:IDisposable
    {
        IQueryable<Trip> GetAllTrips();
        IQueryable<Leg> GetLegsForTrip(int id);
    }
}
