using AutoMapper;
using Concat.API.Model;
using Concat.API.Services;
using Concat.Api.Server.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Concat.API.Infraction.Abstruct;

namespace Concat.Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GotTicketController : ControllerBase
    {
        private readonly IGotTicketRepositories _gotTicketRepositories; // Servisi arabirimle değiştiriyoruz
        private readonly IMapper _mapper;

        public GotTicketController(IGotTicketRepositories gotTicketRepositories, IMapper mapper) // Constructor'da servis arabirimini kullanıyoruz
        {
            _gotTicketRepositories = gotTicketRepositories;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GotTicketDto>>> GetAllTickets() // Dönüş türünü DTO olarak belirliyoruz
        {
            var tickets = await _gotTicketRepositories.GetAll();
            return Ok(_mapper.Map<IEnumerable<GotTicketDto>>(tickets)); // Tickets DTO'ya dönüştürülüyor
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GotTicketDto>> GetTicketById(int id) // Dönüş türünü DTO olarak belirliyoruz
        {
            var ticket = await _gotTicketRepositories.Get(t => t.Id == id);
            if (ticket == null)
                return NotFound();
            return Ok(_mapper.Map<GotTicketDto>(ticket));
        }

        [HttpPost]
        public async Task<ActionResult<GotTicketDto>> AddTicket(GotTicket ticketDto) // Geri dönen sonuç DTO
        {
            int lastOrder = await _gotTicketRepositories.GetAll()
                .ContinueWith(task => task.Result.Any() ? task.Result.Max(t => t.Order) : 0);

            var ticket = new GotTicket
            {
                FirstName = ticketDto.FirstName,
                LastName = ticketDto.LastName,
                Order = lastOrder + 1,
                TicketTime = DateTime.Now
            };

            var createdTicket = await _gotTicketRepositories.Add(ticket);
            return CreatedAtAction(nameof(GetTicketById), new { id = createdTicket.Id }, _mapper.Map<GotTicketDto>(createdTicket));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, GotTicket ticketDto)
        {
            var ticket = await _gotTicketRepositories.Get(t => t.Id == id);
            if (ticket == null)
                return NotFound();

            _mapper.Map(ticketDto, ticket);
            await _gotTicketRepositories.Update(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _gotTicketRepositories.Get(t => t.Id == id);
            if (ticket == null)
                return NotFound();

            await _gotTicketRepositories.Delete(ticket);
            return NoContent();
        }
    }
}
