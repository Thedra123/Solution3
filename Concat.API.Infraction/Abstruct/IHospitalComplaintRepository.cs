using Concat.API.Infraction.Conctret;
using Concat.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concat.API.Infraction.Abstruct
{
    public interface IHospitalComplaintRepository:IRepositories<HospitalComplaint>
    {
        Task<IEnumerable<HospitalComplaint>> GetByHospitalNo(int hospitalNo);
        Task<HospitalComplaint> AddComplaint(HospitalComplaint complaint);
    }
}
