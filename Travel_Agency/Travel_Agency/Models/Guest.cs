using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel_Agency.Models
{
    public class Guest
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public virtual ICollection<Leg> Legs { get; set; }
    }
}