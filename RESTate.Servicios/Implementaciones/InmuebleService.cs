using AutoMapper;
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
    public interface IInmuebleService
    {
        Task<IEnumerable<InmuebleFindDtoResponse>> FindAsync(InmuebleFindDtoRequest request);
    }

    public class InmuebleService : IInmuebleService
    {
        private readonly IInmuebleRepository _inmuebleRepository;
        private readonly IMapper _mapper;

        public InmuebleService(IInmuebleRepository inmuebleRepository, IMapper mapper)
        {
            _inmuebleRepository = inmuebleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InmuebleFindDtoResponse>> FindAsync(InmuebleFindDtoRequest request)
        {
            var predicado = ObtenerPredicado(request);
            var repoResponse = await _inmuebleRepository.FindAsync(predicado);

            return _mapper.Map<IEnumerable<InmuebleFindDtoResponse>>(repoResponse);
        }

        private Expression<Func<Inmueble, bool>> ObtenerPredicado(InmuebleFindDtoRequest request)
        {
            return inmueble => 
                   (request.CantidadDeAmbientesMinimo == null || request.CantidadDeAmbientesMinimo <= inmueble.CantidadAmbientes)
                && (request.CantidadDeAmbientesMaximo == null || request.CantidadDeAmbientesMaximo >= inmueble.CantidadAmbientes)
                && (request.CantidadDeBañosMinimo == null || request.CantidadDeBañosMinimo <= inmueble.CantidadBaños)
                && (request.CantidadDeBañosMaximo == null || request.CantidadDeBañosMaximo >= inmueble.CantidadBaños)
                && (request.CantidadDeDormitoriosMinimo == null || request.CantidadDeDormitoriosMinimo <= inmueble.CantidadDormitorios)
                && (request.CantidadDeDormitoriosMaximo == null || request.CantidadDeDormitoriosMaximo >= inmueble.CantidadDormitorios)
                && (request.MetrosCuadradosMinimo == null || request.MetrosCuadradosMinimo <= inmueble.MetrosCuadrados)
                && (request.MetrosCuadradosMaximo == null || request.MetrosCuadradosMaximo >= inmueble.MetrosCuadrados)
                && (request.MetrosCuadradosCubiertosMinimo == null || request.MetrosCuadradosCubiertosMinimo <= inmueble.MetrosCuadradosCubiertos)
                && (request.MetrosCuadradosCubiertosMaximo == null || request.MetrosCuadradosCubiertosMaximo >= inmueble.MetrosCuadradosCubiertos)
                && (string.IsNullOrEmpty(request.PalabrasClave) || (inmueble.Resumen??"").Contains(request.PalabrasClave) || (inmueble.Descripcion ?? "").Contains(request.PalabrasClave));
        }
    }
}
