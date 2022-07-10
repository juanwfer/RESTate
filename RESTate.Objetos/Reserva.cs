using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Objetos
{
    public class Reserva
    {
        public Contacto Interesado { get; set; }
        public string? MotivoLiberacion { get; internal set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaLiberacion { get; set; }
        public TimeSpan Duracion { get; set; }
        public DateTime FechaVencimiento { get => FechaInicio + Duracion; }
        public bool Vigente { get => FechaLiberacion == null && DateTime.Now < FechaVencimiento; }

        public Reserva(Contacto interesado, DateTime fechaInicio, TimeSpan? duracion = null)
        {
            FechaInicio = fechaInicio;
            Interesado = interesado;
            Duracion = duracion ?? TimeSpan.FromDays(7);
        }

        internal void Liberar(DateTime fechaLiberacion, string motivoLiberacion)
        {
            MotivoLiberacion = motivoLiberacion;
            FechaLiberacion = fechaLiberacion;
        }
    }
}
