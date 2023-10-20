using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Add this namespace for IConfiguration
using TrendyolProduct.Api.Models;

namespace TrendyolProduct.Api
{
    public class TyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductMedia> ProductMedias { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductCampaign> ProductCampaigns { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
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
