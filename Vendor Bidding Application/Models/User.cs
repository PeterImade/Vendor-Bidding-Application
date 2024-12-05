namespace Vendor_Bidding_Application.Models
{
    public class User: BaseModel
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}