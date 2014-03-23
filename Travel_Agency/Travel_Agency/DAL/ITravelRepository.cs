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
        Trip GetTripById(int id);
        Int32 GetMinGuestsForTrip(int id);
        List<Int32> GetAllGuestIDs();
        String GetTripName(int Id);
        Trip AddTrip(Trip t);
        Guest AddGuestToLeg(Guest g, int id);
        String UpdateTripComplete(int tid, bool c);
        String UpdateTripViability(int tid, bool v);
        Leg AddLeg(Leg l);
        IQueryable<Leg> GetLegsForTrip(int id);
        ICollection<Guest> GetGuestsForLeg(int legid);
        Guest GetGuestByName(string nme);
        List<String> GetAllGuestNames();
        List<Guest> GetAllGuests();
        Leg GetLegById(int legid);
    }
}
