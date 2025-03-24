using Concat.Api.Server.Dto;
using Concat.API.Infraction.Abstruct;
using Concat.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Concat.Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepositories _userRepository;

        public RegisterController(IUserRepositories userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // Kullanıcı zaten var mı kontrolü
            var existingUser = await _userRepository.Get(u => u.FirstName == dto.Name);
            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            // Yeni kullanıcı oluşturuluyor
            var newUser = new User
            {
                FirstName = dto.Name,
                Password = dto.Password // Burada şifre hashleme ekleyebilirsin
            };

            await _userRepository.Add(newUser);
            return CreatedAtAction(nameof(Register), new { id = newUser.Id }, "User registered successfully");
        }
    }
}
