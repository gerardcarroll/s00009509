using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel_Agency.Models
{
    public class Leg
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Start Location Is Required")]
        public String StartLocation { get; set; }

        [Required(ErrorMessage = "Finish Location Is Required")]
        public String FinishLocation { get; set; }

        [Required(ErrorMessage = "Start Date Required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Finish Date Required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        public int TripID { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
        public virtual Trip Trip { get; set; }
    }
}