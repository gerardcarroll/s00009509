namespace s00009509_Travel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using s00009509_Travel.Models;
    using System.Collections.Generic;
    using s00009509_Travel.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            ContextKey = "s00009509_Travel.DAL.TravelContext";
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TravelContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Add Seed Trip Data Here
            db.Trips.AddOrUpdate(
                t => t.ID,
                new Trip { ID = 31, Name = "Space Odyssey", StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(30), MinGuests = 5},
                new Trip { ID = 32, Name = "There And Back", StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(21), MinGuests = 3 },
                new Trip { ID = 33, Name = "Around Ireland", StartDate = Convert.ToDateTime("15/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(15), MinGuests = 4 }
                );

            //Add Seed Leg Data Here
            db.Legs.AddOrUpdate(
                l => l.ID,
                new Leg { ID = 1, StartLocation = "Sligo", FinishLocation = "New York", TripID = 31, StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(15) },
                new Leg { ID = 2, StartLocation = "Dublin", FinishLocation = "London", TripID = 32, StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(7) },
                new Leg { ID = 3, StartLocation = "London", FinishLocation = "Paris", TripID = 32, StartDate = Convert.ToDateTime("10/04/2014").AddDays(8), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(14) },
                new Leg { ID = 4, StartLocation = "Paris", FinishLocation = "Dublin", TripID = 32, StartDate = Convert.ToDateTime("10/04/2014").AddDays(15), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(21) }
                );

            //Add Seed Guest Data Here
            db.Guests.AddOrUpdate(
                g => g.ID,
                new Guest { ID = 1, FirstName = "John" },
                new Guest { ID = 2, FirstName = "David" },
                new Guest { ID = 3, FirstName = "Paul" },
                new Guest { ID = 4, FirstName = "Tom" }
                );
        }
    }
}
