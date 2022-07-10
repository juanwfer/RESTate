using AutoMapper;
using RESTate.Datos.Entities;
using RESTate.Datos.Repositorios;
using RESTate.Servicios.Dtos.ServiceRequests;
using RESTate.Servicios.Dtos.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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
            var repoResponse = await _inmuebleRepository.FindAsync(i => true);

            return _mapper.Map<IEnumerable<InmuebleFindDtoResponse>>(repoResponse);
        }
    }
}
