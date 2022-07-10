using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Api.Contracts.RestfulResponses;
using RESTate.Servicios.Dtos.ServiceRequests;
using RESTate.Servicios.Implementaciones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly IInmuebleService _inmuebleService;
        private readonly IMapper _mapper;

        public InmueblesController(IInmuebleService inmuebleService, IMapper mapper)
        {
            _inmuebleService = inmuebleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] InmueblesGetAllRequest request)
        {
            var mappedRequest = _mapper.Map<InmuebleFindDtoRequest>(request);

            var respuesta = await _inmuebleService.FindAsync(mappedRequest);
            return Ok(respuesta);
        }
    }
}
