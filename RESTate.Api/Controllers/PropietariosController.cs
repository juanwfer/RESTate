using Microsoft.AspNetCore.Mvc;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Api.Contracts.RestfulResponses;
using System.Collections.Generic;

namespace RESTate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] PropietariosGetAllRequest request)
        {
            var respuesta = new List<PropietariosGetAllResponse>();
            return Ok(respuesta);
        }
    }
}
