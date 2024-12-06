using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Utils;

namespace Vendor_Bidding_Application.Controllers
{
    [Route("api/auth/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Login(LoginDTO loginDTO)
        {
            var token = TokenGeneration.GenerateToken(loginDTO.Email);
            return Ok(token);
        }
    }
}
