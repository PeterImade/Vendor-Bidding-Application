using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateVendorDTO
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
