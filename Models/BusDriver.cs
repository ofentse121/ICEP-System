using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICEP_System.Models
{
    public class BusDriver
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname  is Required")]
        [StringLength(50)]
        [MinLength(3)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "ID Number is Required")]
        [Display(Name = "ID Number")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(13)]
        [MaxLength(13)]
        public string IDNumber { get; set; }
        [Required(ErrorMessage = "Email is Requred")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        public string EmailUsername { get; set; }   
        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Transport Locations Required")]
        [Display(Name = " Transporting Locations")]
        public string TransportLocations { get; set; }
    }
}