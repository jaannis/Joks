using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDatingSite.Models
{
    using System.Data.Entity;

    public class CatDB : DbContext
    {
        public DbSet<CatProfile> CatProfiles { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Blog> Blogs { get; set; }

    }
}