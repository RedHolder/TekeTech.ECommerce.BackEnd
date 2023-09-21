global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;

using TrendyolProduct.Api.Models;

namespace TrendyolProduct.Api
{
    public class TyContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductURL> ProductURL { get; set; }
        public DbSet<Category> Category { get; set; }


        public TyContext(DbContextOptions<TyContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMFKE7T;Initial Catalog=TrendyolProduct;TrustServerCertificate=true;User ID=sa;Password=Da224356151+");
        }
    }
}
