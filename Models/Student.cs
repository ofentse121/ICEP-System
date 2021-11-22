using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICEP_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is Required")]
        [StringLength(50)]
        [MinLength(3)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Student Number is Required")]
        [Display(Name = "Student Number")]
        [DataType(DataType.PostalCode)]
        [MinLength(9)]
        [MaxLength(9)]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "User name is Required")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(20)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}