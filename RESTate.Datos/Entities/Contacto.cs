using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Datos.Entities
{
    [Table("Contactos")]
    public class Contacto
    {
        [Key]
        public int IdContacto { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int? TipoDocumento { get; set; }
        public long? NumeroDocumento { get; set; }
        public string? Observaciones { get; set; }
        public string? Email { get; set; }

        public virtual IEnumerable<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }

    [Table("Telefonos")]
    public class Telefono
    {
        [Key]
        public int IdTelefono { get; set; }
        public string NumeroTelefono { get; set; } = null!;

        [ForeignKey(nameof(Contacto))]
        public int IdContacto { get; set; }

        public virtual Contacto Contacto { get; set; } = null!;
    }
}
