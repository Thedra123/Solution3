using AutoMapper;
using Concat.API.Model;
using Concat.API.Infraction.Abstruct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Concat.API.Infraction.Conctret;

namespace Concat.API.Services
{
    public class GotTicketServices : IGotTicketRepositories // Servis, arabirimi implement ediyor
    {
        private readonly GotTicketDbContext _gotTicketdb;
        private readonly IMapper _mapper;

        public GotTicketServices(GotTicketDbContext gotTicketdb, IMapper mapper)
        {
            _gotTicketdb = gotTicketdb;
            _mapper = mapper;
        }

        public async Task<GotTicket> Add(GotTicket entity)
        {
            var maxOrder = await _gotTicketdb.GotTicketDbSet
                .OrderByDescending(t => t.Order)
                .Select(t => t.Order)
                .FirstOrDefaultAsync();

            entity.Order = maxOrder + 1;

            await _gotTicketdb.GotTicketDbSet.AddAsync(entity);
            await _gotTicketdb.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(GotTicket entity)
        {
            _gotTicketdb.GotTicketDbSet.Remove(entity);
            return await _gotTicketdb.SaveChangesAsync() > 0;
        }

        public async Task<GotTicket> Get(Expression<Func<GotTicket, bool>> predicate)
        {
            return await _gotTicketdb.GotTicketDbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<GotTicket>> GetAll()
        {
            var tickets = await _gotTicketdb.GotTicketDbSet.ToListAsync();

            // 7 günden eski olanları expired olarak işaretle
            foreach (var ticket in tickets)
            {
                if ((DateTime.Now - ticket.TicketTime).TotalDays > 7 && !ticket.IsExpired)
                {
                    ticket.IsExpired = true;
                    _gotTicketdb.GotTicketDbSet.Update(ticket);
                }
            }

            await _gotTicketdb.SaveChangesAsync();
            return tickets;
        }

        public async Task Update(GotTicket entity)
        {
            _gotTicketdb.GotTicketDbSet.Update(entity);
            await _gotTicketdb.SaveChangesAsync();
        }
    }
}
