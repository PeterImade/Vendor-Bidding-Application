using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class VendorDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; }
    }
}