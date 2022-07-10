using AutoMapper;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Servicios.Dtos.ServiceRequests;

namespace RESTate.Api.MappingProfiles
{
    public class RequestToDto : Profile
    {
        public RequestToDto()
        {
            CreateMap<InmueblesGetAllRequest, InmuebleFindDtoRequest>();
        }
    }
}
