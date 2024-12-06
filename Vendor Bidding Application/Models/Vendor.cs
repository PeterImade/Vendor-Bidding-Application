namespace Vendor_Bidding_Application.Models
{
    public class Vendor: BaseModel
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; } 
        public ICollection<Bid>? Bids { get; set; }
    }
}
