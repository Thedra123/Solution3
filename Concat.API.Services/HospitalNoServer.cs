using Concat.API.Infraction.Conctret;
using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concat.API.Services
{
    public class HospitalNoServer
    {
        private readonly HospitalNoDbContext _context;

        public HospitalNoServer(HospitalNoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HospitalNo>> GetAllAsync()
        {
            return await _context.HospitalNo.ToListAsync();
        }

        public async Task<HospitalNo?> GetByIdAsync(int id)
        {
            return await _context.HospitalNo.FindAsync(id);
        }

        public async Task<HospitalNo> AddAsync(HospitalNo hospitalNo)
        {
            _context.HospitalNo.Add(hospitalNo);
            await _context.SaveChangesAsync();
            return hospitalNo;
        }

        public async Task<bool> UpdateAsync(int id, HospitalNo updatedHospitalNo)
        {
            var existingHospitalNo = await _context.HospitalNo.FindAsync(id);
            if (existingHospitalNo == null)
                return false;

            existingHospitalNo.Hospitalno = updatedHospitalNo.Hospitalno;
            existingHospitalNo.Hospitalname = updatedHospitalNo.Hospitalname;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hospitalNo = await _context.HospitalNo.FindAsync(id);
            if (hospitalNo == null)
                return false;

            _context.HospitalNo.Remove(hospitalNo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
