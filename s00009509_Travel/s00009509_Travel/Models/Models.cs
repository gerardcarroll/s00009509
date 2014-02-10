using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace s00009509_Travel.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int MinGuests { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }

    }

    public class Leg
    {
        public int ID { get; set; }
        public String StartLocation { get; set; }
        public String FinishLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }

    public class Guest
    {
        public int ID { get; set; }
        public String FirstName { get; set; }

    }

    public class TravelContext : DbContext
    {
        public TravelContext() : base("TravelContext")
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }

    public class TravelAgencyInitializer : DropCreateDatabaseAlways<TravelContext>
    {
        protected override void Seed(TravelContext db)
        {
            //Add Initial Data Here
            var trips = new List<Trip>
            {
                new Trip{Name = "Space Odyssey", StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(30), MinGuests = 5},
                new Trip{Name = "There And Back", StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(20), MinGuests = 3}

            };

            trips.ForEach(t => db.Trips.Add(t));

        }
    }
}