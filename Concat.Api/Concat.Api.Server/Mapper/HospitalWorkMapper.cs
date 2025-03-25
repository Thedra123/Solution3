using AutoMapper;
using Concat.API.Model;

namespace Concat.Api.Server.Mapper
{
    public class HospitalWorkMapper:Profile
    {
        public HospitalWorkMapper() {
            CreateMap<HospitalWorkDto, HospitalWork>();
        }
    }
}
