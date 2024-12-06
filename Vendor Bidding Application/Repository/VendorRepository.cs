using Microsoft.EntityFrameworkCore;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Repository
{
    public class VendorRepository: GenericRepository<Vendor>, IVendorRepository
    {
        private readonly AppDbContext _dbContext;

        public VendorRepository(AppDbContext dbContext): base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Vendor> GetVendorByEmailAsync(string email)
        {
            return await _dbContext.Vendors.Where(vendor => vendor.Email == email).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
