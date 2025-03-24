using AutoMapper;
using Concat.Api.Server.Dto;
using Concat.API.Infraction.Conctret;
using Concat.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concat.Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalNoController : ControllerBase
    {
        private readonly HospitalNoDbContext _context;
        private readonly IMapper _mapper;

        public HospitalNoController(HospitalNoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalNo>>> Get()
        {
            var hospitalNos = await _context.HospitalNo.ToListAsync();
            var result = _mapper.Map<IEnumerable<HospitalNo>>(hospitalNos);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalNo>> Get(int id)
        {
            var hospitalNo = await _context.HospitalNo.FindAsync(id);
            if (hospitalNo == null) return NotFound();

            var result = _mapper.Map<HospitalNo>(hospitalNo);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HospitalNo>> Post([FromBody] HospitalNoDto dto)
        {
            var hospitalNo = _mapper.Map<HospitalNo>(dto);
            _context.HospitalNo.Add(hospitalNo);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<HospitalNo>(hospitalNo);
            return CreatedAtAction(nameof(Get), new { id = hospitalNo.Hospitalno }, result);
        }
    }
}
