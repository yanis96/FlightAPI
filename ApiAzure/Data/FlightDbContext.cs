using ApiAzure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAzure.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Avion> Avions { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
