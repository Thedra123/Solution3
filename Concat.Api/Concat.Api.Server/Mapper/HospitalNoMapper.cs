using AutoMapper;
using Concat.Api.Server.Dto;
using Concat.API.Model;

namespace Concat.Api.Server.Mapper
{
    public class HospitalNoMapper:Profile
    {
        public HospitalNoMapper()
        {
            CreateMap<HospitalNoDto, HospitalNo>();
        }
    }
}
