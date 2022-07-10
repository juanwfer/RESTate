using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Servicios.Dtos.ServiceRequests
{
    public class InmuebleFindDtoRequest
    {
        public int? CantidadDeAmbientesMinimo { get; set; }
        public int? CantidadDeAmbientesMaximo { get; set; }
        public int? CantidadDeDormitoriosMinimo { get; set; }
        public int? CantidadDeDormitoriosMaximo { get; set; }
        public int? CantidadDeBañosMinimo { get; set; }
        public int? CantidadDeBañosMaximo { get; set; }
        public int? MetrosCuadradosMinimo { get; set; }
        public int? MetrosCuadradosMaximo { get; set; }
        public int? MetrosCuadradosCubiertosMinimo { get; set; }
        public int? MetrosCuadradosCubiertosMaximo { get; set; }
        public string? PalabrasClave { get; set; }
    }
}
