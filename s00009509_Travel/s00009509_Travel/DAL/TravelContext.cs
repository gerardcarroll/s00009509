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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TravelContext, Configuration>());
        }
    }
    
}