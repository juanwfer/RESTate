using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTate.Api.Contracts.RestfulRequests;
using RESTate.Api.Contracts.RestfulResponses;
using System.Collections.Generic;

namespace RESTate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] InmueblesGetAllRequest request)
        {
            var respuesta = new List<InmueblesGetAllResponse>();
            return Ok(respuesta);
        }
    }
}
