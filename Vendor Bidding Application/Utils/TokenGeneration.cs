using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Vendor_Bidding_Application.Utils
{
    public class TokenGeneration
    {
        public static string GenerateToken(int id)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("66a90af64da3d22639cbfad9fec6adac3576c13867298f359e164bfdd89a3360"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(45),
                claims: claims,
                signingCredentials: creds
           );
           
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;
        }
    }
}
