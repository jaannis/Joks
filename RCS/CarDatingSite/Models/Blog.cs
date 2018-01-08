using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDatingSite.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.IO;

    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Display(Name = "e-pasta adrese")]
        [Required(ErrorMessage = "Ievadiet lūdzu e-pastu")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string BlogEmail { get; set; }


        [Display(Name = "Vārds")]
        [Required(ErrorMessage = "Kā tevi sauc?")]
        public string BlogName { get; set; }

        [Display(Name = "Virsraksts")]
        [Required(ErrorMessage = "Par ko stāstīsi?")]
        public string BlogTitle { get; set; }


        [Display(Name = "Ieraksts")]
        [Required(ErrorMessage = "Ko labu vēlies pateikt?")]
        public string BlogText { get; set; }

        [Display(Name = "Kaķa bilde")]
        public string BlogImage { get; set; }
                
    }
}