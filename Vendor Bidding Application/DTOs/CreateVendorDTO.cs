using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateVendorDTO
    {
        [Required(ErrorMessage = "The vendor name is required.")]
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [Required(ErrorMessage = "The email field is required.")]
        public string Email { get; set; }
         
    }
}
