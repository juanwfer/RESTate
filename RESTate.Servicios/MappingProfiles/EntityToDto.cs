using AutoMapper;
using RESTate.Datos.Entities;
using RESTate.Servicios.Dtos.ServiceResponses;

namespace RESTate.Servicios.MappingProfiles
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Inmueble, InmuebleFindDtoResponse>();
        }
    }
}
