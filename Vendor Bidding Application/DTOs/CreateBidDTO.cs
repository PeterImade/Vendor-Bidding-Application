using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateBidDTO
    {
        [Required]
        public int VendorId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
