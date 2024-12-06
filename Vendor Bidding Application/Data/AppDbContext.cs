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

    }
}
