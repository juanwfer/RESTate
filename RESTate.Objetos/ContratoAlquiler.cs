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
        public DateTime? FechaFirma { get; private set; }
        public bool Vigente { get => !(FechaFirma is null) && FechaRescision is null; }
        public DateTime? FechaInicioPlazo { get; private set; }
        public DateTime? FechaFinalizacionPlazo { get; private set; }
        public double MontoPactadoInicial { get; private set; }
        public string? UbicacionDocumento { get; set; }
        public DateTime? FechaRescision { get; set; }

        public ContratoAlquiler(Inmueble inmueble, Contacto inquilino)
        {
            DateTime fecha = DateTime.Now;
            var reserva = inmueble.ReservaActivaALaFecha(fecha);
            if (!(reserva is null) && reserva.Interesado != inquilino)
                throw new DominioException("No se puede confeccionar un contrato para un inmueble reservado por otra persona");

            if (inmueble.Propietario is null)
                throw new DominioException("No se puede confeccionar un contrato para un inmueble sin propietario");

            Inmueble = inmueble;
            Propietario = inmueble.Propietario;
            Inquilino = inquilino;
        }

        public void Firmar(DateTime fechaFirma)
        {
            if (MontoPactadoInicial <= 0)
                throw new DominioException("No se puede firmar el contrato de locación sin establecer el monto pactado inicial");

            if (FechaInicioPlazo is null || FechaFinalizacionPlazo is null)
                throw new DominioException("No se puede firmar el contrato de locación sin establecer el plazo completo");

            Inmueble.HistorialContratos.Add(this);

            FechaFirma = fechaFirma;
        }

        public void EstablecerPlazo(DateTime fechaInicio, DateTime fechaFinalizacion)
        {
            FechaInicioPlazo = fechaInicio;
            FechaFinalizacionPlazo = fechaFinalizacion;
        }

        public void EstablecerMontoPactado(double montoPactado)
        {
            if (Vigente)
                throw new DominioException("No se puede modificar el monto pactado inicial una vez firmado el contrato");

            MontoPactadoInicial = montoPactado;
        }

        public void Rescindir(DateTime fechaRescision, string motivoRescision)
        {
            FechaRescision = fechaRescision;
        }
    }
}
