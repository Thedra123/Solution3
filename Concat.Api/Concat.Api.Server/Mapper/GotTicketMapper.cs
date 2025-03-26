using AutoMapper;
using Concat.API.Model;
using Concat.Api.Server.Dto;

namespace Concat.Api.Server.Mapper
{
    public class GotTicketMapper
    {
        public class GotTicketProfile : Profile
        {
            public GotTicketProfile()
            {
                CreateMap<GotTicket, GotTicketDto>().ReverseMap();
            }
        }
    }
}
