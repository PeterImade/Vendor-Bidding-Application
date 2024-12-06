using System.ComponentModel.DataAnnotations.Schema;

namespace Vendor_Bidding_Application.Models
{
    public class Bid: BaseModel
    {
        public int VendorId { get; set; }
        public int ProjectId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Submitted";

        [ForeignKey("VendorId")]
        public Vendor? Vendor { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
    }
}
