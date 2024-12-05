using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateProjectDTO
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Budget { get; set; }
    }
}
