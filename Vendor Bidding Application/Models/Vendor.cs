namespace Vendor_Bidding_Application.Models
{
    public class Vendor: BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Bid>? Bids { get; set; }
    }
}
