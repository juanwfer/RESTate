using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RESTate.Datos.Entities
{
    [Table("Inmuebles")]
    public class Inmueble
    {
        [Key]
        public int IdInmueble { get; set; }
        public string Resumen { get; set; } = "";
        public string? Descripcion { get; set; }
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public int CantidadDeAmbientes { get; set; }
        public int CantidadDeDormitorios{ get; set; }
        public int CantidadDeBaños { get; set; }

        public IEnumerable<Reserva> HistorialReservas { get; set; } = new List<Reserva>();
        public IEnumerable<PropietarioHistorico> HistorialPropietarios { get; set; } = new List<PropietarioHistorico>();
    }

    [Table("PropietariosHistoricos")]
    public class PropietarioHistorico
    {
        [Key]
        public int IdPropietarioHistorico { get; set; }
        public string MotivoEntrada { get; set; } = null!;
        public string? MotivoSalida { get; set; }

        [ForeignKey(nameof(Propietario))]
        public int IdContactoPropietario { get; set; }

        public virtual Contacto Propietario { get; set; } = null!;
    }
}
