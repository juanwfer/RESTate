using Microsoft.AspNetCore.Mvc;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Api.Contracts.RestfulResponses;
using System.Collections.Generic;

namespace RESTate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] ContactosGetAllRequest request)
        {
            var respuesta = new List<ContactosGetAllResponse>();
            return Ok(respuesta);
        }
    }
}
