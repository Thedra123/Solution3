using AutoMapper;
using Concat.Api.Server.Dto;
using Concat.API.Model;

namespace Concat.Api.Server.Mapper
{
    public class UserMapper:Profile
    {
        public UserMapper() 
        {
            CreateMap<User, UserDto>();
        }
    }
}
