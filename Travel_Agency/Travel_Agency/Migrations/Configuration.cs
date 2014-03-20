namespace Travel_Agency.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Travel_Agency.Models;
    using Travel_Agency.DAL;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Travel_Agency.DAL.TravelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;            
        }

        protected override void Seed(Travel_Agency.DAL.TravelContext db)
        {
            //Add Seed Trip Data Here
            db.Trips.AddOrUpdate(
                t => t.ID,
                new Trip { ID = 1, Name = "Space Odyssey", StartDate = DateTime.Now.Date, FinishDate = DateTime.Now.AddDays(9), MinGuests = 5 },
                new Trip { ID = 2, Name = "There And Back", StartDate = DateTime.Parse("10/04/2014"), FinishDate = DateTime.Parse("10/04/2014").AddDays(9), MinGuests = 5 },
                new Trip { ID = 3, Name = "Around Ireland", StartDate = DateTime.Parse("15/04/2014"), FinishDate = DateTime.Parse("15/04/2014").AddDays(9), MinGuests = 3 },
                new Trip { ID = 5, Name = "Six Nations", StartDate = DateTime.Parse("01/02/2015"), FinishDate = DateTime.Parse("01/02/2015").AddDays(30), MinGuests = 3 },
                new Trip { ID = 6, Name = "Around The World", StartDate = DateTime.Parse("01/05/2014"), FinishDate = DateTime.Parse("01/05/2014").AddDays(80), MinGuests = 4 }
                );

            //Add Seed Leg Data Here
            db.Legs.AddOrUpdate(
                l => l.ID,
                //Trip 1 Legs
                new Leg { ID = 9, StartLocation = "Dublin", FinishLocation = "Florida", TripID = 1, StartDate = DateTime.Now, FinishDate = DateTime.Now.AddDays(1), Guests = new List<Guest>() },
                new Leg { ID = 10, StartLocation = "Florida", FinishLocation = "Mars", TripID = 1, StartDate = DateTime.Now.AddDays(2), FinishDate = DateTime.Now.AddDays(3), Guests = new List<Guest>() },
                new Leg { ID = 11, StartLocation = "Mars", FinishLocation = "Venus", TripID = 1, StartDate = DateTime.Now.AddDays(4), FinishDate = DateTime.Now.AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 12, StartLocation = "Venus", FinishLocation = "Jupiter", TripID = 1, StartDate = DateTime.Now.AddDays(6), FinishDate = DateTime.Now.AddDays(7), Guests = new List<Guest>() },
                new Leg { ID = 13, StartLocation = "Jupiter", FinishLocation = "The Sun", TripID = 1, StartDate = DateTime.Now.AddDays(8), FinishDate = DateTime.Now.AddDays(9), Guests = new List<Guest>() },

                //Trip 2 Legs
                new Leg { ID = 14, StartLocation = "Dublin", FinishLocation = "London", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(1), Guests = new List<Guest>() },
                new Leg { ID = 15, StartLocation = "London", FinishLocation = "Paris", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(2), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(3), Guests = new List<Guest>() },
                new Leg { ID = 16, StartLocation = "Paris", FinishLocation = "Berlin", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(4), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 17, StartLocation = "Berlin", FinishLocation = "Rome", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(6), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(7), Guests = new List<Guest>() },
                new Leg { ID = 18, StartLocation = "Rome", FinishLocation = "Dublin", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(8), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(9), Guests = new List<Guest>() },

                //Trip 3 Legs
                new Leg { ID = 19, StartLocation = "Sligo", FinishLocation = "Galway", TripID = 3, StartDate = Convert.ToDateTime("15/04/2014"), FinishDate = Convert.ToDateTime("15/04/2014").AddDays(1), Guests = new List<Guest>() },
                new Leg { ID = 20, StartLocation = "Cork", FinishLocation = "Waterford", TripID = 3, StartDate = Convert.ToDateTime("15/04/2014").AddDays(4), FinishDate = Convert.ToDateTime("15/04/2014").AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 21, StartLocation = "Dublin", FinishLocation = "Sligo", TripID = 3, StartDate = Convert.ToDateTime("15/04/2014").AddDays(8), FinishDate = Convert.ToDateTime("15/04/2014").AddDays(9), Guests = new List<Guest>() },

                //Trip 4 Legs
                new Leg { ID = 22, StartLocation = "Ireland", FinishLocation = "Italy", TripID = 5, StartDate = Convert.ToDateTime("01/02/2015"), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 23, StartLocation = "Italy", FinishLocation = "France", TripID = 5, StartDate = Convert.ToDateTime("01/02/2015").AddDays(6), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(10), Guests = new List<Guest>() },
                new Leg { ID = 24, StartLocation = "France", FinishLocation = "England", TripID = 5, StartDate = Convert.ToDateTime("01/02/2015").AddDays(11), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(15), Guests = new List<Guest>() },
                new Leg { ID = 25, StartLocation = "England", FinishLocation = "Wales", TripID = 5, StartDate = Convert.ToDateTime("01/02/2015").AddDays(16), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(20), Guests = new List<Guest>() },
                new Leg { ID = 26, StartLocation = "Scotland", FinishLocation = "Dublin", TripID = 5, StartDate = Convert.ToDateTime("01/02/2015").AddDays(26), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(30), Guests = new List<Guest>() },

                //Trip 5 Legs
                new Leg { ID = 27, StartLocation = "Dublin", FinishLocation = "Istanbul", TripID = 6, StartDate = Convert.ToDateTime("01/05/2014"), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(16), Guests = new List<Guest>() },
                new Leg { ID = 28, StartLocation = "Istanbul", FinishLocation = "Singapore", TripID = 6, StartDate = Convert.ToDateTime("01/05/2014").AddDays(17), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(32), Guests = new List<Guest>() },
                new Leg { ID = 29, StartLocation = "Singapore", FinishLocation = "Auckland", TripID = 6, StartDate = Convert.ToDateTime("01/05/2014").AddDays(33), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(48), Guests = new List<Guest>() },
                new Leg { ID = 30, StartLocation = "Auckland", FinishLocation = "Los Angeles", TripID = 6, StartDate = Convert.ToDateTime("01/05/2014").AddDays(49), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(64), Guests = new List<Guest>() }
                );
            

            //Add Seed Guest Data Here
            db.Guests.AddOrUpdate(
                g => g.ID,
                new Guest { ID = 1, FirstName = "John", Legs = new List<Leg>() },
                new Guest { ID = 2, FirstName = "David", Legs = new List<Leg>() },
                new Guest { ID = 3, FirstName = "Paul", Legs = new List<Leg>() },
                new Guest { ID = 4, FirstName = "Tom", Legs = new List<Leg>() },
                new Guest { ID = 6, FirstName = "Simon", Legs = new List<Leg>() },
                new Guest { ID = 7, FirstName = "Robert", Legs = new List<Leg>() },
                new Guest { ID = 8, FirstName = "Susie", Legs = new List<Leg>() },
                new Guest { ID = 9, FirstName = "Sandra", Legs = new List<Leg>() },
                new Guest { ID = 10, FirstName = "Mary", Legs = new List<Leg>() },
                new Guest { ID = 11, FirstName = "Fred", Legs = new List<Leg>() },
                new Guest { ID = 12, FirstName = "Joe", Legs = new List<Leg>() }
                );

            //Add Guests for Trip 1 Legs
            AddOrUpdateGuest(db, 9, 1);
            AddOrUpdateGuest(db, 10, 1);
            AddOrUpdateGuest(db, 9, 2);
            AddOrUpdateGuest(db, 10, 2);
            AddOrUpdateGuest(db, 11, 3);
            AddOrUpdateGuest(db, 12, 3);
            AddOrUpdateGuest(db, 12, 4);
            AddOrUpdateGuest(db, 13, 4);
            AddOrUpdateGuest(db, 12, 6);
            AddOrUpdateGuest(db, 13, 6);

            //Add Guests for Trip 2 Legs
            AddOrUpdateGuest(db, 14, 1);
            AddOrUpdateGuest(db, 15, 1);
            AddOrUpdateGuest(db, 15, 2);
            AddOrUpdateGuest(db, 16, 2);
            AddOrUpdateGuest(db, 15, 9);
            AddOrUpdateGuest(db, 17, 9);
            AddOrUpdateGuest(db, 17, 11);
            AddOrUpdateGuest(db, 18, 11);

            //Add Guests for Trip 3 Legs
            AddOrUpdateGuest(db, 19, 1);
            AddOrUpdateGuest(db, 19, 2);
            AddOrUpdateGuest(db, 20, 2);
            AddOrUpdateGuest(db, 20, 4);
            AddOrUpdateGuest(db, 21, 7);
            AddOrUpdateGuest(db, 21, 8);
            AddOrUpdateGuest(db, 21, 4);
            AddOrUpdateGuest(db, 20, 8);

            //Add Guests for Trip 4 Legs
            AddOrUpdateGuest(db, 22, 1);
            AddOrUpdateGuest(db, 22, 2);
            AddOrUpdateGuest(db, 23, 1);
            AddOrUpdateGuest(db, 24, 2);
            AddOrUpdateGuest(db, 24, 7);
            AddOrUpdateGuest(db, 25, 7);
            AddOrUpdateGuest(db, 26, 10);
            AddOrUpdateGuest(db, 26, 8);

            //Add Guests for Trip 5 Legs
            AddOrUpdateGuest(db, 27, 4);
            AddOrUpdateGuest(db, 27, 6);
            AddOrUpdateGuest(db, 28, 4);
            AddOrUpdateGuest(db, 28, 6);
            AddOrUpdateGuest(db, 29, 7);
            AddOrUpdateGuest(db, 29, 9);
            AddOrUpdateGuest(db, 30, 7);
            AddOrUpdateGuest(db, 30, 10);

            db.SaveChanges();            
        }

        private void AddOrUpdateGuest(TravelContext db, int legId, int guestId)
        {
            var leg = db.Legs.SingleOrDefault(l => l.ID == legId);
            var guest = leg.Guests.SingleOrDefault(g => g.ID == guestId);
            if (guest == null)
                leg.Guests.Add(db.Guests.Single(g => g.ID == guestId));
        }
    }
}
