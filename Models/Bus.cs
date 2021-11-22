using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICEP_System.Models
{
    public class Bus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bus Name is Required")]
        [Display(Name = "Bus Name")]
        public string BusName { get; set; }
        [Required(ErrorMessage = " Starting Campus Location is Required")]
        [Display(Name = "From Location")]
        public string FromDestination { get; set; }
        [Required(ErrorMessage = "Ending Campus Location is Required")]
        [Display(Name = "To Location")]
        public string ToDestination { get; set; }
        [Required(ErrorMessage = "PickUP Time is required")]
        [DataType(DataType.Time)]
        public string PickUpTime { get; set; }

        [Required(ErrorMessage = "PickUp Student Count is Requred")]
        public int PickUpCount { get; set; }
        public int TotalRequest { get; set; } 
    }
}