using Microsoft.AspNetCore.Mvc;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Api.Contracts.RestfulResponses;
using System.Collections.Generic;

namespace RESTate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] InquilinosGetAllRequest request)
        {
            var respuesta = new List<InquilinosGetAllResponse>();
            return Ok(respuesta);
        }
    }
}
