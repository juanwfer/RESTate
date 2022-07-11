using AutoMapper;
using RESTate.Datos.Entities;
using RESTate.Servicios.Dtos.ServiceResponses;
using System.Linq;

namespace RESTate.Servicios.MappingProfiles
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Inmueble, InmuebleFindDtoResponse>();
            CreateMap<Contacto, ContactoFindDtoResponse>()
                .ForMember(d => d.Telefono, opt => opt.MapFrom(s => s.Telefonos.First().NumeroTelefono));
        }
    }
}
