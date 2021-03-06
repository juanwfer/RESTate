using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Objetos
{
    public class Reserva
    {
        public Contacto Interesado { get; private set; }
        public string? MotivoLiberacion { get; internal set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime? FechaLiberacion { get; private set; }
        public DateTime FechaVencimiento { get; private set; }

        public bool VigenteALaFecha(DateTime fecha)
        {
            return FechaLiberacion == null && fecha <= FechaVencimiento && fecha >= FechaInicio;
        }

        public Reserva(Contacto interesado, DateTime fechaInicio, DateTime? fechaVencimiento = null)
        {
            FechaInicio = fechaInicio;
            Interesado = interesado;
            FechaVencimiento = fechaVencimiento ?? fechaInicio.AddDays(7);
        }

        internal void Liberar(DateTime fechaLiberacion, string motivoLiberacion)
        {
            MotivoLiberacion = motivoLiberacion;
            FechaLiberacion = fechaLiberacion;
        }
    }
}
