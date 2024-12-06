using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Utils;

namespace Vendor_Bidding_Application.Controllers
{
    [Route("api/auth/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IVendorRepository vendorRepository;

        public AuthController(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        {
            var vendor = await vendorRepository.GetVendorByEmailAsync(email: loginDTO.Email);

            if (vendor == null) {
                return NotFound("Password or Email is incorrect");
            }

            if (loginDTO.Password != vendor.Password)
            {
                return NotFound("Password or Email is incorrect");
            }
            
            var token = TokenGeneration.GenerateToken(vendor.Id);

            return Ok(token);
        }
    }
}
