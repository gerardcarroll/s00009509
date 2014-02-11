using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace s00009509_Travel.Models
{
    public class Leg
    {
        public int ID { get; set; }
        public String StartLocation { get; set; }
        public String FinishLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}