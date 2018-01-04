﻿using System;
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

        [Required]
        public string CatName { get; set; }

        public int CatAge { get; set; }

        public string CatImage { get; set; }

        [Required]
        public string CatDescription { get; set; }
    }
}