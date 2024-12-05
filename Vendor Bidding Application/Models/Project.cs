namespace Vendor_Bidding_Application.Models
{
    public class Project: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public ICollection<Bid>? Bids { get; set; }
    }
}
