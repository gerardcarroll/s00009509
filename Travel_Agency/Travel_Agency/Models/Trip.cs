using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel_Agency.Models
{
    public class Trip
    {
        public int ID { get; set; }
        [Display(Name = "Trip Name")]
        [Required(ErrorMessage = "Name Is Required")]
        public String Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), Display(Name = "Finish Date")]        
        public DateTime FinishDate { get; set; }
        //[Required(ErrorMessage = "Min Guests Is Required")]
        [Range(3, 10, ErrorMessage = "{0} has to be a number between {1} and {2}")]
        [Display(Name = "Min Guests")]
        public int MinGuests { get; set; }
        public bool Viable { get; set; }
        public bool Complete { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }
    }
}