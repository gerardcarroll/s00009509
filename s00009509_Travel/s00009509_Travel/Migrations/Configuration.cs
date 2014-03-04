namespace s00009509_Travel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using s00009509_Travel.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<s00009509_Travel.DAL.TravelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "s00009509_Travel.DAL.TravelContext";
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(s00009509_Travel.DAL.TravelContext db)
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

            //Add Initial Data Here
            var trips = new List<Trip>
            {
                new Trip{Name = "Space Odyssey", StartDate = DateTime.Now.AddDays(10), FinishDate = DateTime.Now.AddDays(30), MinGuests = 5},
                new Trip{Name = "There And Back", StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(20), MinGuests = 3}

            };

            trips.ForEach(t => db.Trips.Add(t));
            db.SaveChanges();
        }
    }
}
