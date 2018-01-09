using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDatingSite.Models
{
    public class BlogsForIndex
    {
        [Key]
        public int BlogId { get; set; }

        public string BlogCreatorID { get; set; }
        public string BlogCreatorEmail { get; set; }

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

        public DateTime BlogCreated { get; set; }

        public DateTime BlogModified { get; set; }
    }
}