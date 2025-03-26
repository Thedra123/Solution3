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
    public class HospitalWorkServices : IHospitalWorkRepositories
    {
        private readonly HospitalWorkDbContext _hospitalworkdb;

        public HospitalWorkServices(HospitalWorkDbContext hospitalworkdb)
        {
            _hospitalworkdb = hospitalworkdb;
        }

        public async Task<HospitalWork> Add(HospitalWork entity)
        {
            await _hospitalworkdb.Works.AddAsync(entity);
            await _hospitalworkdb.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(HospitalWork entity)
        {
            _hospitalworkdb.Works.Remove(entity);
            return await _hospitalworkdb.SaveChangesAsync() > 0;
        }

        public async Task<HospitalWork> Get(Expression<Func<HospitalWork, bool>> predicate)
        {
            return await _hospitalworkdb.Works.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<HospitalWork>> GetAll()
        {
            return await _hospitalworkdb.Works.ToListAsync(); 
        }


        public async Task Update(HospitalWork entity)
        {
            _hospitalworkdb.Works.Update(entity);
            await _hospitalworkdb.SaveChangesAsync();
        }

        
    }

}
