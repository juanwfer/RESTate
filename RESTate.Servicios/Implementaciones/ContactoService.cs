using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTate.Datos.Entities;
using RESTate.Datos.Repositorios;
using RESTate.Servicios.Dtos.ServiceRequests;
using RESTate.Servicios.Dtos.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTate.Servicios.Implementaciones
{
    public interface IContactoService
    {
        Task<IEnumerable<ContactoFindDtoResponse>> FindAsync(ContactoFindDtoRequest request);
    }

    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _inmuebleRepository;
        private readonly IMapper _mapper;

        public ContactoService(IContactoRepository inmuebleRepository, IMapper mapper)
        {
            _inmuebleRepository = inmuebleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactoFindDtoResponse>> FindAsync(ContactoFindDtoRequest request)
        {
            var predicado = ObtenerPredicado(request);
            var repoResponse = await _inmuebleRepository.FindAsync(predicado, I => I.Include(c => c.Telefonos));

            return _mapper.Map<IEnumerable<ContactoFindDtoResponse>>(repoResponse);
        }

        private Expression<Func<Contacto, bool>> ObtenerPredicado(ContactoFindDtoRequest request)
        {
            return contacto => 
                (request.Telefono == null || contacto.Telefonos.Select(t => t.NumeroTelefono).Contains(request.Telefono))
                && (request.Nombre == null || contacto.NombreCompleto.Contains(request.Nombre))
                && (request.Email == null || (contacto.Email??"").Contains(request.Email))
                && (request.TipoDocumento == null || contacto.TipoDocumento.ToString() == request.TipoDocumento)
                && (request.NumeroDocumento == null || contacto.NumeroDocumento == request.NumeroDocumento)
                && (string.IsNullOrEmpty(request.PalabrasClave)
                    || contacto.NombreCompleto.Contains(request.PalabrasClave??"")
                    || (contacto.Observaciones??"").Contains(request.PalabrasClave??""));
        }
    }
}
