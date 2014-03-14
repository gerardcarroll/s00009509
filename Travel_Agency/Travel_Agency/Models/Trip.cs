using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel_Agency.Models
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
}