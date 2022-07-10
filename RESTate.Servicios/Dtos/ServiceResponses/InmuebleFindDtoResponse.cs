using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Servicios.Dtos.ServiceResponses
{
    public class InmuebleFindDtoResponse
    {
        public int IdInmueble { get; set; }
        public string Resumen { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public int CantidadAmbientes { get; set; }
        public int CantidadDormitorios { get; set; }
        public int CantidadBaños { get; set; }
    }
}
