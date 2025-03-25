using AutoMapper;
using Concat.Api.Server.Dto;
using Concat.API.Infraction.Abstruct;
using Concat.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concat.Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositories _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserRepositories userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userServices.GetAll();
            var db = _mapper.Map<IEnumerable<User>>(users);
            return Ok(db);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userServices.Get(u => u.Id == id);
            if (user == null) return NotFound();

            var dataToReturn = _mapper.Map<User>(user);
            return Ok(dataToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDto item)
        {
            var user = _mapper.Map<User>(item);
            var returnEntity = await _userServices.Add(user);

            var dataToReturn = _mapper.Map<User>(returnEntity);
            return Ok(dataToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto item)
        {
            var existingUser = await _userServices.Get(u => u.Id == id);
            if (existingUser == null)
                return NotFound($"User with ID {id} not found.");

            _mapper.Map(item, existingUser); 
            await _userServices.Update(existingUser);

            return NoContent(); 
        }
    }
}
