using AutoMapper;
using RESTate.Api.Contracts.RestfulResponses;
using RESTate.Servicios.Dtos.ServiceResponses;

namespace RESTate.Api.MappingProfiles
{
    public class DtoToResponse : Profile
    {
        public DtoToResponse()
        {
            CreateMap<InmuebleFindDtoResponse, InmueblesGetAllResponse>()
                .ForMember(d => d.Link, opt => opt.MapFrom(s => $"inmuebles/{s.IdInmueble}"));
        }
    }
}
