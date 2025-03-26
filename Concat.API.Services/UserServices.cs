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
    public class UserServices : IUserRepositories
    {
        private readonly UserDbContext _userdb;

        public UserServices(UserDbContext userdb)
        {
            _userdb = userdb;
        }

        public async Task<User> Add(User entity)
        {
            await _userdb.Users.AddAsync(entity);
            await _userdb.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(User entity)
        {
            _userdb.Users.Remove(entity);
            return await _userdb.SaveChangesAsync() > 0;
        }

        public async Task<User> Get(Expression<Func<User, bool>> predicate)
        {
            return await _userdb.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userdb.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int Id)
        {
            return await _userdb.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Update(User entity)
        {
            _userdb.Users.Update(entity);
            await _userdb.SaveChangesAsync();
        }

        

        
    }

}
