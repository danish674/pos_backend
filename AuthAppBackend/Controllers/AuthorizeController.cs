using AuthAppBackend.Helper;
using AuthAppBackend.ModelTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly TestDbContext context;
        private readonly JwtSettings jwtSettings;
        public AuthorizeController(TestDbContext context, IOptions<JwtSettings> options)
        {
            this.context = context;
            this.jwtSettings = options.Value;
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] UserCred cred)
        {
            APIResponse response = new APIResponse();
            try
            {
                var user = await this.context.TblUsers.FirstOrDefaultAsync(x => x.Code == cred.Username && x.Password == cred.Password);
                if (user != null)
                {
                    // Generate Token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.UTF8.GetBytes(this.jwtSettings.SecurityKey);
                    var tokendesc = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.Code),
                    new Claim(ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddSeconds(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                    };

                    var token = tokenHandler.CreateToken(tokendesc);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(tokenString);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }
        }

    }
}
