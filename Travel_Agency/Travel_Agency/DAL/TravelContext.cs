using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Travel_Agency.Models;
//using Travel_Agency.Migrations;

namespace Travel_Agency.DAL
{
    public class TravelContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }
        

        public TravelContext() : base("TravelContext3")
        {            
            
        }
    }
    
}