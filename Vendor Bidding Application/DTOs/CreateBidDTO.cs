using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateBidDTO
    {
        [Required(ErrorMessage = "Vendor ID is required.")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Project ID is required.")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Bid amount is required.")]
        public decimal Amount { get; set; }
    }
}