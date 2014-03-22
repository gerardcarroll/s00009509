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
        String GetTripName(int Id);
        Trip AddTrip(Trip t);
        Leg AddLeg(Leg l);
        IQueryable<Leg> GetLegsForTrip(int id);
        ICollection<Guest> GetGuestsForLeg(int legid);
        IQueryable<Guest> GetAllGuests();
        Leg GetLegById(int legid);
    }
}
