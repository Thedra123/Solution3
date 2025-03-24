using Concat.API.Infraction.Abstruct;
using Concat.API.Infraction.Conctret;
using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Concat.API.Services
{
    public class GotTicketServices : IGotTicketRepositories
    {
        private GotTicketDbContext _GotTicketdb;

        public GotTicketServices(GotTicketDbContext gotTicketdb)
        {
            _GotTicketdb = gotTicketdb;
        }

        public async Task<GotTicket> Add(GotTicket entity)
        {
            await _GotTicketdb.GotTicketDbSet.AddAsync(entity);
            await _GotTicketdb.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(GotTicket entity)
        {
            _GotTicketdb.GotTicketDbSet.Remove(entity);
            return await _GotTicketdb.SaveChangesAsync() > 0;
        }

        public async Task<GotTicket> Get(Expression<Func<GotTicket, bool>> predicate)
        {
            return await _GotTicketdb.GotTicketDbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<GotTicket>> GetAll()
        {
            return await _GotTicketdb.GotTicketDbSet.ToListAsync();
        }

        public async Task Update(GotTicket entity)
        {
            _GotTicketdb.GotTicketDbSet.Update(entity);
            await _GotTicketdb.SaveChangesAsync();
        }

        Task<GotTicket> IRepositories<GotTicket>.Delete(GotTicket entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<GotTicket> IRepositories<GotTicket>.GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
