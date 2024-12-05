using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
