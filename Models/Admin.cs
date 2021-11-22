using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICEP_System.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "User name is Required")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        [MaxLength(50)]

        public string AdminUserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(20)]
        [MinLength(5)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}