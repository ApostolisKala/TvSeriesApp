using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TvSeriesApp.Models
{
    public class SerieDbContext : DbContext
    {
        public DbSet<Serie> Series { get; set; }
       
    }
}