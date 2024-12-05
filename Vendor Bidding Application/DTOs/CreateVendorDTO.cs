using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateVendorDTO
    {
        [Required(ErrorMessage = "The vendor name is required.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [Required(ErrorMessage = "The email field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at 6 characters long")]
        public string Password { get; set; }
    }
}
