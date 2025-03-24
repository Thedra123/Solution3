using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Concat.API.Infraction.Abstruct
{
    public interface IRepositories<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task<T> Delete(T entity);
    }
}
