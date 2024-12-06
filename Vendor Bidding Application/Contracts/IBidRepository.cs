using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Contracts
{
    public interface IBidRepository: IGenericRepository<Bid>
    {
        Task<List<Bid>> FindBidsByVendorId(int vendorId);    
    }
}
