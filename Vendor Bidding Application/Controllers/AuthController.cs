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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
