using Concat.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concat.API.Infraction.Abstruct
{
    public interface IAdminRepositories : IRepositories<Admin>
    {
        Task<IEnumerable<Admin>> GetAll();
    }
}
