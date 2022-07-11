using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Api.Contracts.RestfulResponses;
using RESTate.Servicios.Dtos.ServiceRequests;
using RESTate.Servicios.Implementaciones;
using System.Collections.Generic;

namespace RESTate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinosController : ControllerBase
    {
        private readonly IContactoService _contactoService;
        private readonly IMapper _mapper;

        public InquilinosController(IContactoService contactoService, IMapper mapper)
        {
            _contactoService = contactoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] InquilinosGetAllRequest request)
        {
            var mappedRequest = _mapper.Map<InquilinoFindDtoRequest>(request);
            var respuesta = _contactoService.FindInquilinosAsync(mappedRequest);

            return Ok(respuesta);
        }
    }
}
