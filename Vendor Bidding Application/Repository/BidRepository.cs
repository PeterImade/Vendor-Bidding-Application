using Microsoft.EntityFrameworkCore;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Repository
{
    public class BidRepository: GenericRepository<Bid>, IBidRepository
    {
        private readonly AppDbContext _dbContext;

        public BidRepository(AppDbContext dbContext): base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Bid>> FindBidsByVendorId(int vendorId)
        { 
            return await _dbContext.Bids.Where(bid => bid.VendorId == vendorId).AsNoTracking().ToListAsync();
        }
    }
}
