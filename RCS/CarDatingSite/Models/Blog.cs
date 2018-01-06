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
        public int PostId { get; set; }

        [Display(Name = "e-pasta adrese")]
        [Required(ErrorMessage = "Ievadiet lūdzu e-pastu")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PostEmail { get; set; }


        [Display(Name = "Vārds")]
        [Required(ErrorMessage = "Kā tevi sauc?")]
        public string PostName { get; set; }

        [Display(Name = "Virsraksts")]
        [Required(ErrorMessage = "Par ko stāstīsi?")]
        public string PostTitle { get; set; }


        [Display(Name = "Ieraksts")]
        [Required(ErrorMessage = "Ko labu vēlies pateikt?")]
        public string PostText { get; set; }

        [Display(Name = "Kaķa bilde")]
        public string PostImage { get; set; }

    }
}