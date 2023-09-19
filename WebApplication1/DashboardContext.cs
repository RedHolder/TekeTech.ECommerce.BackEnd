global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DashboardContext : DbContext
    {

        public DbSet<Orders> Orders { get; set; }
        public DbSet<ProductModel_Trendyol> TrendyolProductModel { get; set; }

        public DashboardContext(DbContextOptions<DashboardContext> options) : base(options) { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMFKE7T;Initial Catalog=BekirSpor;TrustServerCertificate=true;User ID=sa;Password=Da224356151+");
        }

    }
}
