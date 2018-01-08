using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarDatingSite.Models
{
    public class BildeBlogam
    {
        public int BildeBlogamId { get; set; }
        [StringLength(255)]
        public string bildeBlogamName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int CatProfileId { get; set; }

        [Required]
        public virtual Blog BlogProfile { get; set; }
    }
}