using AutoMapper;
using Concat.API.Model;
using Concat.API.Infraction.Abstruct;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concat.API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalWorkController : ControllerBase
    {
        private readonly IHospitalWorkRepositories _hospitalWorkServices; 
        private readonly IMapper _mapper;

        public HospitalWorkController(IHospitalWorkRepositories hospitalWorkServices, IMapper mapper)
        {
            _hospitalWorkServices = hospitalWorkServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalWork>>> GetAllWorks()
        {
            var works = await _hospitalWorkServices.GetAll();
            return Ok(_mapper.Map<IEnumerable<HospitalWork>>(works));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalWork>> GetWorkById(int id)
        {
            var work = await _hospitalWorkServices.Get(h => h.Id == id);
            if (work == null)
                return NotFound();
            return Ok(_mapper.Map<HospitalWork>(work));
        }

        [HttpPost]
        public async Task<ActionResult<HospitalWork>> AddWork(HospitalWorkDto workDto)
        {
            var work = _mapper.Map<HospitalWork>(workDto);
            var createdWork = await _hospitalWorkServices.Add(work);
            return CreatedAtAction(nameof(GetWorkById), new { id = createdWork.Id }, _mapper.Map<HospitalWork>(createdWork));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWork(int id, HospitalWorkDto workDto)
        {
            var work = await _hospitalWorkServices.Get(h => h.Id == id);
            if (work == null)
                return NotFound();

            _mapper.Map(workDto, work);
            await _hospitalWorkServices.Update(work);
            return NoContent();
        }
    }
}
