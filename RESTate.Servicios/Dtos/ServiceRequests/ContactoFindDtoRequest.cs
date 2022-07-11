using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Servicios.Dtos.ServiceRequests
{
    public class ContactoFindDtoRequest
    {
        public long? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? PalabrasClave { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
