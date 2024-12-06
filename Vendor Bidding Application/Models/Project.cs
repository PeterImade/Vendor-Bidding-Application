using System.Text.Json.Serialization;
namespace Vendor_Bidding_Application.Models
{
    public class Project: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }

        [JsonIgnore]
        public ICollection<Bid>? Bids { get; set; }
    }
}
