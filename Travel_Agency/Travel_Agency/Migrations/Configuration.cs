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
                new Trip { ID = 1, Name = "Space Odyssey", StartDate = DateTime.Now.Date, FinishDate = DateTime.Now.AddDays(9), MinGuests = 5, Viable = true, Complete = true },
                new Trip { ID = 2, Name = "There And Back", StartDate = DateTime.Parse("10/04/2014"), FinishDate = DateTime.Parse("10/04/2014").AddDays(9), MinGuests = 5, Viable = false, Complete = true },
                new Trip { ID = 3, Name = "Around Ireland", StartDate = DateTime.Parse("15/04/2014"), FinishDate = DateTime.Parse("15/04/2014").AddDays(9), MinGuests = 3, Viable = false, Complete = false },
                new Trip { ID = 4, Name = "Six Nations", StartDate = DateTime.Parse("01/02/2015"), FinishDate = DateTime.Parse("01/02/2015").AddDays(30), MinGuests = 3, Viable = true, Complete = false },
                new Trip { ID = 5, Name = "Around The World", StartDate = DateTime.Parse("01/05/2014"), FinishDate = DateTime.Parse("01/05/2014").AddDays(80), MinGuests = 4, Viable = false, Complete = false }
                );

            //Add Seed Leg Data Here
            db.Legs.AddOrUpdate(
                l => l.ID,
                //Trip 1 Legs
                new Leg { ID = 1, StartLocation = "Dublin", FinishLocation = "Florida", TripID = 1, StartDate = DateTime.Now, FinishDate = DateTime.Now.AddDays(1), Guests = new List<Guest>() },
                new Leg { ID = 2, StartLocation = "Florida", FinishLocation = "Mars", TripID = 1, StartDate = DateTime.Now.AddDays(2), FinishDate = DateTime.Now.AddDays(3), Guests = new List<Guest>() },
                new Leg { ID = 3, StartLocation = "Mars", FinishLocation = "Venus", TripID = 1, StartDate = DateTime.Now.AddDays(4), FinishDate = DateTime.Now.AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 4, StartLocation = "Venus", FinishLocation = "Jupiter", TripID = 1, StartDate = DateTime.Now.AddDays(6), FinishDate = DateTime.Now.AddDays(7), Guests = new List<Guest>() },
                new Leg { ID = 5, StartLocation = "Jupiter", FinishLocation = "The Sun", TripID = 1, StartDate = DateTime.Now.AddDays(8), FinishDate = DateTime.Now.AddDays(9), Guests = new List<Guest>() },

                //Trip 2 Legs
                new Leg { ID = 6, StartLocation = "Dublin", FinishLocation = "London", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014"), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(1), Guests = new List<Guest>() },
                new Leg { ID = 7, StartLocation = "London", FinishLocation = "Paris", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(2), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(3), Guests = new List<Guest>() },
                new Leg { ID = 8, StartLocation = "Paris", FinishLocation = "Berlin", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(4), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 9, StartLocation = "Berlin", FinishLocation = "Rome", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(6), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(7), Guests = new List<Guest>() },
                new Leg { ID = 10, StartLocation = "Rome", FinishLocation = "Dublin", TripID = 2, StartDate = Convert.ToDateTime("10/04/2014").AddDays(8), FinishDate = Convert.ToDateTime("10/04/2014").AddDays(9), Guests = new List<Guest>() },

                //Trip 3 Legs
                new Leg { ID = 11, StartLocation = "Sligo", FinishLocation = "Galway", TripID = 3, StartDate = Convert.ToDateTime("15/04/2014"), FinishDate = Convert.ToDateTime("15/04/2014").AddDays(1), Guests = new List<Guest>() },
                new Leg { ID = 12, StartLocation = "Cork", FinishLocation = "Waterford", TripID = 3, StartDate = Convert.ToDateTime("15/04/2014").AddDays(4), FinishDate = Convert.ToDateTime("15/04/2014").AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 13, StartLocation = "Dublin", FinishLocation = "Sligo", TripID = 3, StartDate = Convert.ToDateTime("15/04/2014").AddDays(8), FinishDate = Convert.ToDateTime("15/04/2014").AddDays(9), Guests = new List<Guest>() },

                //Trip 4 Legs
                new Leg { ID = 14, StartLocation = "Ireland", FinishLocation = "Italy", TripID = 4, StartDate = Convert.ToDateTime("01/02/2015"), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(5), Guests = new List<Guest>() },
                new Leg { ID = 15, StartLocation = "Italy", FinishLocation = "France", TripID = 4, StartDate = Convert.ToDateTime("01/02/2015").AddDays(6), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(10), Guests = new List<Guest>() },
                new Leg { ID = 16, StartLocation = "France", FinishLocation = "England", TripID = 4, StartDate = Convert.ToDateTime("01/02/2015").AddDays(11), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(15), Guests = new List<Guest>() },
                new Leg { ID = 17, StartLocation = "England", FinishLocation = "Wales", TripID = 4, StartDate = Convert.ToDateTime("01/02/2015").AddDays(16), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(20), Guests = new List<Guest>() },
                new Leg { ID = 18, StartLocation = "Scotland", FinishLocation = "Dublin", TripID = 4, StartDate = Convert.ToDateTime("01/02/2015").AddDays(26), FinishDate = Convert.ToDateTime("01/02/2015").AddDays(30), Guests = new List<Guest>() },

                //Trip 5 Legs
                new Leg { ID = 19, StartLocation = "Dublin", FinishLocation = "Istanbul", TripID = 5, StartDate = Convert.ToDateTime("01/05/2014"), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(16), Guests = new List<Guest>() },
                new Leg { ID = 20, StartLocation = "Istanbul", FinishLocation = "Singapore", TripID = 5, StartDate = Convert.ToDateTime("01/05/2014").AddDays(17), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(32), Guests = new List<Guest>() },
                new Leg { ID = 21, StartLocation = "Singapore", FinishLocation = "Auckland", TripID = 5, StartDate = Convert.ToDateTime("01/05/2014").AddDays(33), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(48), Guests = new List<Guest>() },
                new Leg { ID = 22, StartLocation = "Auckland", FinishLocation = "Los Angeles", TripID = 5, StartDate = Convert.ToDateTime("01/05/2014").AddDays(49), FinishDate = Convert.ToDateTime("01/05/2014").AddDays(64), Guests = new List<Guest>() }
                );
            

            //Add Seed Guest Data Here
            db.Guests.AddOrUpdate(
                g => g.ID,
                new Guest { ID = 1, FirstName = "John", Legs = new List<Leg>() },
                new Guest { ID = 2, FirstName = "David", Legs = new List<Leg>() },
                new Guest { ID = 3, FirstName = "Paul", Legs = new List<Leg>() },
                new Guest { ID = 4, FirstName = "Tom", Legs = new List<Leg>() },
                new Guest { ID = 5, FirstName = "Simon", Legs = new List<Leg>() },
                new Guest { ID = 6, FirstName = "Robert", Legs = new List<Leg>() },
                new Guest { ID = 7, FirstName = "Susie", Legs = new List<Leg>() },
                new Guest { ID = 8, FirstName = "Sandra", Legs = new List<Leg>() },
                new Guest { ID = 9, FirstName = "Mary", Legs = new List<Leg>() },
                new Guest { ID = 10, FirstName = "Fred", Legs = new List<Leg>() },
                new Guest { ID = 11, FirstName = "Joe", Legs = new List<Leg>() }
                );

            //Add Guests for Trip 1 Legs
            AddOrUpdateGuest(db, 1, 1);
            AddOrUpdateGuest(db, 2, 1);
            AddOrUpdateGuest(db, 1, 2);
            AddOrUpdateGuest(db, 2, 2);
            AddOrUpdateGuest(db, 3, 3);
            AddOrUpdateGuest(db, 3, 3);
            AddOrUpdateGuest(db, 4, 4);
            AddOrUpdateGuest(db, 5, 4);
            AddOrUpdateGuest(db, 4, 6);
            AddOrUpdateGuest(db, 5, 6);

            //Add Guests for Trip 2 Legs
            AddOrUpdateGuest(db, 6, 1);
            AddOrUpdateGuest(db, 7, 1);
            AddOrUpdateGuest(db, 7, 2);
            AddOrUpdateGuest(db, 8, 2);
            AddOrUpdateGuest(db, 7, 9);
            AddOrUpdateGuest(db, 9, 9);
            AddOrUpdateGuest(db, 9, 11);
            AddOrUpdateGuest(db, 10, 11);

            //Add Guests for Trip 3 Legs
            AddOrUpdateGuest(db, 11, 1);
            AddOrUpdateGuest(db, 11, 2);
            AddOrUpdateGuest(db, 12, 2);
            AddOrUpdateGuest(db, 12, 4);
            AddOrUpdateGuest(db, 13, 7);
            AddOrUpdateGuest(db, 13, 8);
            AddOrUpdateGuest(db, 13, 4);
            AddOrUpdateGuest(db, 12, 8);

            //Add Guests for Trip 4 Legs
            AddOrUpdateGuest(db, 14, 1);
            AddOrUpdateGuest(db, 14, 2);
            AddOrUpdateGuest(db, 15, 1);
            AddOrUpdateGuest(db, 16, 2);
            AddOrUpdateGuest(db, 16, 7);
            AddOrUpdateGuest(db, 17, 7);
            AddOrUpdateGuest(db, 18, 10);
            AddOrUpdateGuest(db, 18, 8);

            //Add Guests for Trip 5 Legs
            AddOrUpdateGuest(db, 19, 4);
            AddOrUpdateGuest(db, 19, 6);
            AddOrUpdateGuest(db, 20, 4);
            AddOrUpdateGuest(db, 20, 6);
            AddOrUpdateGuest(db, 21, 7);
            AddOrUpdateGuest(db, 21, 9);
            AddOrUpdateGuest(db, 22, 7);
            AddOrUpdateGuest(db, 22, 10);

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
