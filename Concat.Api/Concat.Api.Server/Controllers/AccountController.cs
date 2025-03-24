using Concat.Api.Server.Dto;
using Concat.API.Infraction.Abstruct;
using Concat.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Concat.Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepositories _userRepository;
        private readonly IConfiguration _configuration;

        public AccountController(IUserRepositories userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<User>> SignIn([FromBody] SightInDto dto)
        {
            var user = await _userRepository.Get(s => s.FirstName == dto.Name && s.Password == dto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, dto.Name),
                    new Claim("Fullname", user.FirstName ?? string.Empty) // Null check added
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenData = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenData });
        }
    }
}
