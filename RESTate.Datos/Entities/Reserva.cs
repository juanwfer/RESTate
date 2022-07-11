using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Datos.Entities
{
    [Table("Reservas")]
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public string? MotivoLiberacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaLiberacion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        [ForeignKey(nameof(Inmueble))]
        public int IdInmueble { get; set; }

        [ForeignKey(nameof(ContactoInteresado))]
        public int IdContactoInteresado { get; set; }

        public virtual Contacto ContactoInteresado { get; set; } = null!;
        public Inmueble Inmueble { get; set; } = null!;
    }
}
