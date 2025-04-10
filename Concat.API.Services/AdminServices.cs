using Concat.API.Infraction.Abstruct;
using Concat.API.Infraction.Conctret;
using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Concat.API.Services
{
    public class AdminServices : IAdminRepositories
    {
        private readonly AdminDbContext _adminDb;
        public AdminServices(AdminDbContext adminDb) { _adminDb = adminDb; }
        public async Task<Admin> Add(Admin entity)
        {
            await _adminDb.Admins.AddAsync(entity);
            await _adminDb.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Delete(Admin entity)
        {
            _adminDb.Admins.Remove(entity);
            return await _adminDb.SaveChangesAsync() > 0;
        }
        public async Task<Admin> Get(Expression<Func<Admin, bool>> predicate)
        {
            return await _adminDb.Admins.FirstOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _adminDb.Admins.ToListAsync();
        }
        public async Task Update(Admin entity)
        {
            _adminDb.Admins.Update(entity);
            await _adminDb.SaveChangesAsync();
        }
    }
}