using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICEP_System.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        [Display(Name = "Download Link")]
        public string FilePath { get; set; }
        public DateTime DatePosted { get; set; }
    }
}