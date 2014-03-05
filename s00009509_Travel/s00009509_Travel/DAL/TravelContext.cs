using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using s00009509_Travel.Models;
using s00009509_Travel.Migrations;

namespace s00009509_Travel.DAL
{
    public class TravelContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public TravelContext() : base("TravelContext")
        {            
            //Database.SetInitializer(new TravelInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TravelContext, Configuration>());
        }
    }
    public class TravelInitializer : DropCreateDatabaseAlways<TravelContext>
    {
        //protected override void Seed(TravelContext db)
        //{
        //    //Add Initial Data Here
        //    var trips = new List<Trip>
        //    {
        //        new Trip{Name = "Space Odyssey", StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(30), MinGuests = 5},
        //        new Trip{Name = "There And Back", StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(20), MinGuests = 3}

        //    };

        //    trips.ForEach(t => db.Trips.Add(t));
        //    db.SaveChanges();

        //}
    }
}