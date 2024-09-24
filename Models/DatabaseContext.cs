using Microsoft.EntityFrameworkCore;
using System;

namespace SEROTECA_WEB_BACK.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PortaMuestra> PortaMuestra { get; set; }
        public DbSet<OrdenPortaMuestra> OrdenPortaMuestra { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


    }
}
