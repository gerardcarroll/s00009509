using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using s00009509_Travel.Models;

namespace s00009509_Travel.DAL
{
    public interface ITravelRepository:IDisposable
    {
        IQueryable<Trip> GetAllTrips();
    }
}
