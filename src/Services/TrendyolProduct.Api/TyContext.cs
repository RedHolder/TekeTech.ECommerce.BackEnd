using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Add this namespace for IConfiguration
using TrendyolProduct.Api.Models;

namespace TrendyolProduct.Api
{
    public class TyContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductURL> ProductURL { get; set; }
        public DbSet<Category> Category { get; set; }

        private readonly IConfiguration _configuration; // Add a private field for IConfiguration

        public TyContext(DbContextOptions<TyContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Use the connection string from appsettings.json
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
