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

            //Add Initial Trip Data Here
            db.Trips.AddOrUpdate(
                t => t.Name,
                new Trip { Name = "Space Odyssey", StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(30), MinGuests = 5},
                new Trip { Name = "There And Back", StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(10), MinGuests = 3 }
                );

            db.Legs.AddOrUpdate(
                l => l.StartLocation,
                new Leg { StartLocation = "Sligo", FinishLocation = "New York", TripID = 25, StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(15) },
                new Leg { StartLocation = "Dublin", FinishLocation = "London", TripID = 26, StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(10) }
                );

        }
    }
}
