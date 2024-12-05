using System.ComponentModel.DataAnnotations.Schema;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public Vendor? Vendor { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Submitted";
    }
}
