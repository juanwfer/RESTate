using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RESTate.Datos.Entities
{
    public class Inmueble
    {
        [Key]
        public int IdInmueble { get; set; }
        public string? Resumen { get; set; }
        public string? Descripcion { get; set; }
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public int CantidadAmbientes { get; set; }
        public int CantidadDormitorios{ get; set; }
        public int CantidadBaños { get; set; }
    }
}
