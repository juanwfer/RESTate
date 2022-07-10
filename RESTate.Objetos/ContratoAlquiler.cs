using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Objetos
{
    public class ContratoAlquiler
    {
        public Inmueble Inmueble { get; }
        public Contacto Propietario { get; }
        public Contacto Inquilino { get; }
        public DateTime? FechaFirma { get; set; } = null;
        public bool Vigente { get => !(FechaFirma is null); }
        public DateTime? FechaInicioPlazo { get; private set; }
        public DateTime? FechaFinalizacionPlazo { get; private set; }
        public int MontoPactadoInicial { get; set; }
        public string? UbicacionDocumento { get; set; } = null;

        public ContratoAlquiler(Inmueble inmueble, Contacto propietario, Contacto inquilino)
        {
            if (!(inmueble.ReservaActiva is null) && inmueble.ReservaActiva.Interesado != inquilino)
                throw new DominioException("No se puede confeccionar un contrato para un inmueble reservado por otra persona");

            Inmueble = inmueble;
            Propietario = propietario;
            Inquilino = inquilino;
        }

        public void Firmar(DateTime fechaFirma)
        {
            if (MontoPactadoInicial <= 0)
                throw new DominioException("No se puede firmar el contrato de locación sin establecer el monto pactado inicial");

            if (FechaInicioPlazo is null || FechaFinalizacionPlazo is null)
                throw new DominioException("No se puede firmar el contrato de locación sin establecer el plazo completo");

            FechaFirma = fechaFirma;
        }

        public void EstablecerPlazo(DateTime fechaInicio, DateTime fechaFinalizacion)
        {
            FechaInicioPlazo = fechaInicio;
            FechaFinalizacionPlazo = fechaFinalizacion;
        }
    }
}
