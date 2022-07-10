using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTate.Objetos
{
    public class Inmueble
    {
        public string Resumen { get; set; }
        public int CantidadDeAmbientes { get; set; }
        public int CantidadDeDormitorios { get; set; }
        public int CantidadDeBaños { get; set; }
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public Contacto? Propietario { get; set; }
        public Contacto? Inquilino { get; set; }
        public Reserva? ReservaActiva { get => HistorialReservas.FirstOrDefault(reserva => reserva.Vigente); }
        public List<Reserva> HistorialReservas { get; set; } = new List<Reserva>();

        public Inmueble(string resumen, int cantidadDeAmbientes, int cantidadDeDormitorios, int cantidadDeBaños, int metrosCuadrados, int metrosCuadradosCubiertos, Contacto? propietario = null, Contacto? inquilino = null)
        {
            Resumen = resumen;
            CantidadDeAmbientes = cantidadDeAmbientes;
            CantidadDeDormitorios = cantidadDeDormitorios;
            CantidadDeBaños = cantidadDeBaños;
            MetrosCuadrados = metrosCuadrados;
            MetrosCuadradosCubiertos = metrosCuadradosCubiertos;
            Propietario = propietario;
            Inquilino = inquilino;
        }

        public void Reservar(Contacto contacto, DateTime fechaInicio, TimeSpan? duracion = null)
        {
            if (!(ReservaActiva is null))
                throw new DominioException("No se puede reservar el inmueble previamente reservado");

            HistorialReservas.Add(new Reserva(contacto, fechaInicio, duracion));
        }

        public void LiberarReserva(DateTime fechaLiberacion, string motivoLiberacion)
        {
            if (ReservaActiva is null)
                throw new DominioException("No se puede liberar el inmueble no reservado");

            ReservaActiva.Liberar(fechaLiberacion, motivoLiberacion);
        }
    }
}