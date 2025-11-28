using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Starlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("VerifyUser")]
        public async Task<IActionResult> VerifyUser([FromBody] UserLogin userLogin)
        {
            if (userLogin == null)
            {
                return BadRequest();
            }
            try
            {
                var user = await _authRepository.GetUserAsync(userLogin);
                if (user is not null)
                {
                    var jwtSection = _configuration.GetSection("Jwt");
                    var jwtOptions = jwtSection.Get<JwtOptions>();

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Name, user.Name),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var token = new JwtSecurityToken(
                        issuer: jwtOptions.Issuer,
                        audience: jwtOptions.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(jwtOptions.ExpiryMinutes),
                        signingCredentials: creds);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new
                    {
                        token = tokenString,
                        expiresIn = jwtOptions.ExpiryMinutes * 60
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
