using AutoMapper;
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
    public class ContactosController : ControllerBase
    {
        private readonly IContactoService _contactoService;
        private readonly IMapper _mapper;

        public ContactosController(IContactoService contactoService, IMapper mapper)
        {
            _contactoService = contactoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ContactosGetAllRequest request)
        {
            var mappedRequest = _mapper.Map<ContactoFindDtoRequest>(request);

            var respuesta = await _contactoService.FindAsync(mappedRequest);
            return Ok(respuesta);
        }
    }
}
