using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Contracts
{
    public interface IVendorRepository: IGenericRepository<Vendor>
    {
        Task<Vendor> GetVendorByEmailAsync(string email); 
    }
}
