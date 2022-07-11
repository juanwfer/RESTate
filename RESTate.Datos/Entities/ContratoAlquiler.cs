using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Datos.Entities
{
    [Table("ContratosAlquiler")]
    public class ContratoAlquiler
    {
        [Key]
        public int IdContratoAlquiler { get; set; }
        public DateTime? FechaFirma { get; set; }
        public DateTime? FechaInicioPlazo { get; set; }
        public DateTime? FechaFinalizacionPlazo { get; set; }
        public double MontoPactadoInicial { get; set; }
        public string? UbicacionDocumento { get; set; }
        public DateTime? FechaRescision { get; set; }

        [ForeignKey(nameof(Inmueble))]
        public int IdInmueble { get; set; }

        [ForeignKey(nameof(ContactoInquilino))]
        public int IdContactoInquilino { get; set; }

        [ForeignKey(nameof(ContactoPropietario))]
        public int IdContactoPropietario { get; set; }

        public virtual Inmueble Inmueble { get; set; } = null!;
        public virtual Contacto ContactoPropietario { get; set; } = null!;
        public virtual Contacto ContactoInquilino { get; set; } = null!;
    }
}
