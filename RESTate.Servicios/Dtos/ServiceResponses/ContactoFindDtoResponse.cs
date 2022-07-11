using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Servicios.Dtos.ServiceResponses
{
    public class ContactoFindDtoResponse
    {
        public int IdContacto { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public int NumeroDocumento { get; set; }
    }
}
