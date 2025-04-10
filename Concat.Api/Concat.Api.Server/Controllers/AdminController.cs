using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Concat.API.Infraction.Abstruct;
using Concat.API.Model;
using Concat.Api.Server.Dto;
namespace Concat.Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepositories _adminRepo;
        private readonly IConfiguration _configuration;
        public AdminController(IAdminRepositories adminRepo, IConfiguration configuration)
        {
            _adminRepo = adminRepo;
            _configuration = configuration;
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult<object>> SignIn([FromBody] SightInDto dto)
        {
            var admin = await _adminRepo.Get(s => s.FirstName == dto.Name && s.Password == dto.Password);
            if (admin == null) return Unauthorized("Invalid credentials");
            var token = GenerateJwtToken(admin);
            return Ok(new { Token = token });
        }
        private string GenerateJwtToken(Admin admin)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, admin.FirstName),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}