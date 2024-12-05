using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Repository
{
    public class VendorRepository: GenericRepository<Vendor>, IVendorRepository
    {
        private readonly AppDbContext dbContext;

        public VendorRepository(AppDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
