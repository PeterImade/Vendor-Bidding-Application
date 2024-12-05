using System.Net;

namespace Vendor_Bidding_Application.Models
{
    public class APIResponse
    {
        public bool Status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; } 
        public List<string> Errors { get; set; }
    }
}
