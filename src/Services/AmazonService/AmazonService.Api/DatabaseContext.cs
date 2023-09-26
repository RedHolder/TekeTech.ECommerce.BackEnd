using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AmazonService.Api.Models;

namespace AmazonService.Api
{
    public class DatabaseContext : DbContext
    {

        public DbSet<ASIN> ASIN { get; set; }
        public DbSet<SKIN> SKIN { get; set; }
        public DbSet<AmazonOrders> AmazonOrders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMFKE7T;Initial Catalog=Amazon;TrustServerCertificate=true;User ID=sa;Password=Da224356151+");
        }
    }
}
