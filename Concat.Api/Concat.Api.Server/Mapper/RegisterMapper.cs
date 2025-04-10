using AutoMapper;
using Concat.Api.Server.Dto;
using Concat.API.Model;

namespace Concat.Api.Server.Mapper
{
    public class RegisterMapper:Profile
    {
        public RegisterMapper() 
        {
            CreateMap<RegisterDto, User>()
    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)) 
    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        }
    }
}
