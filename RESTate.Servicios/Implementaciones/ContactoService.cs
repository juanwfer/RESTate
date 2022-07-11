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
        Task<IEnumerable<InquilinoFindDtoResponse>> FindInquilinosAsync(InquilinoFindDtoRequest request);
        Task<IEnumerable<PropietarioFindDtoResponse>> FindPropietariosAsync(PropietarioFindDtoRequest request);
    }

    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _contactoRepository;
        private readonly IMapper _mapper;

        public ContactoService(IContactoRepository inmuebleRepository, IMapper mapper)
        {
            _contactoRepository = inmuebleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactoFindDtoResponse>> FindAsync(ContactoFindDtoRequest request)
        {
            var predicado = ObtenerPredicado(request);
            var repoResponse = await _contactoRepository.FindAsync(predicado, I => I.Include(c => c.Telefonos));

            return _mapper.Map<IEnumerable<ContactoFindDtoResponse>>(repoResponse);
        }

        public async Task<IEnumerable<InquilinoFindDtoResponse>> FindInquilinosAsync(InquilinoFindDtoRequest request)
        {
            var predicado = ObtenerPredicado(request);
            var repoResponse = await _contactoRepository.FindAsync(predicado, I => I.Include(c => c.ContratosComoInquilino));

            return _mapper.Map<IEnumerable<InquilinoFindDtoResponse>>(repoResponse);
        }

        public async Task<IEnumerable<PropietarioFindDtoResponse>> FindPropietariosAsync(PropietarioFindDtoRequest request)
        {
            var predicado = ObtenerPredicado(request);

            var repoResponse = await _contactoRepository.FindAsync(predicado, I => I.Include(c => c.ContratosComoPropietario));
            return _mapper.Map<IEnumerable<PropietarioFindDtoResponse>>(repoResponse);
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

        private Expression <Func<Contacto, bool>> ObtenerPredicado(InquilinoFindDtoRequest request)
        {
            return contacto =>
                (contacto.ContratosComoInquilino.Any(c => c.FechaRescision == null || c.FechaRescision >= DateTime.Now));
        }

        private Expression<Func<Contacto, bool>> ObtenerPredicado(PropietarioFindDtoRequest request)
        {
            return contacto =>
                (contacto.ContratosComoPropietario.Any(c => c.FechaRescision == null || c.FechaRescision >= DateTime.Now));
        }
    }
}
