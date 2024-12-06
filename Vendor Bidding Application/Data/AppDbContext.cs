using Microsoft.EntityFrameworkCore;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
            new { Name = "Project Alpha", Description = "A construction project for a new office building", Budget = 5000000, Currency = "USD", Category = "Construction" },
            new { Name = "Project Beta", Description = "A marketing campaign for a new product launch", Budget = 200000, Currency = "USD", Category = "Marketing" },
            new { Name = "Project Gamma", Description = "Software development for a mobile app", Budget = 150000, Currency = "EUR", Category = "Software" },
            new { Name = "Project Delta", Description = "Renovation of a historical museum", Budget = 1000000, Currency = "GBP", Category = "Construction" },
            new { Name = "Project Epsilon", Description = "Research project for AI technologies", Budget = 300000, Currency = "USD", Category = "Research" },
            new { Name = "Project Zeta", Description = "Branding and graphic design for a startup", Budget = 50000, Currency = "USD", Category = "Design" },
            new { Name = "Project Eta", Description = "Web development for a new e-commerce platform", Budget = 120000, Currency = "EUR", Category = "Software" },
            new { Name = "Project Theta", Description = "Construction of a bridge over a river", Budget = 8000000, Currency = "USD", Category = "Construction" },
            new { Name = "Project Iota", Description = "Mobile game development", Budget = 250000, Currency = "USD", Category = "Software" },
            new { Name = "Project Kappa", Description = "Product development for a new consumer gadget", Budget = 1000000, Currency = "GBP", Category = "Product Design" }
            );
        }
    }
}
