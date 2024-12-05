using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class VendorLoginDTO
    {
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Required(ErrorMessage = "The email field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Incorrect password.")]
        public string Password { get; set; }
    }
}