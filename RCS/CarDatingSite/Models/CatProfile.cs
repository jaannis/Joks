using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDatingSite.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CatProfile
    {
        [Key]        
        public int CatId { get; set; }

        [Display(Name = "Kaķa vārds")]
        [Required(ErrorMessage = "Kaķim jabūt vārdam")]
        public string CatName { get; set; }

        [Display(Name = "Kaķa Vecums")]
        [Range(1,20, ErrorMessage = "Kaķa vecumam jābūt no 1 līdz 20 gadiem")]
        public int CatAge { get; set; }

        [Display(Name = "Kaķa bilde")]
        public string CatImage { get; set; }

        [Display(Name = "Kaķa apraksts")]
        [Required(ErrorMessage = "Kaut kam labam taču jābūt")]
        public string CatDescription { get; set; }
    }
}