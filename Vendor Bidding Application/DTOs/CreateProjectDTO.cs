using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class CreateProjectDTO
    { 
        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Project description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Project Bugdet is required.")]
        public decimal Budget { get; set; }
    }
}
