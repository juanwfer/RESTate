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
        public Contacto? Propietario { get => HistorialPropietarios.LastOrDefault()?.Propietario; }
        public Contacto? Inquilino { get; private set; }
        public Reserva? ReservaActiva { get => HistorialReservas.FirstOrDefault(reserva => reserva.Vigente); }
        public List<Reserva> HistorialReservas { get; private set; } = new List<Reserva>();
        public List<PropietarioHistorico> HistorialPropietarios { get; set; } = new List<PropietarioHistorico>();
        public ContratoAlquiler? ContratoActivo { get => HistorialContratos.FirstOrDefault(contrato => contrato.Vigente); }
        public List<ContratoAlquiler> HistorialContratos { get; set; } = new List<ContratoAlquiler>();

        public Inmueble(string resumen, int cantidadDeAmbientes, int cantidadDeDormitorios, int cantidadDeBaños, int metrosCuadrados, int metrosCuadradosCubiertos, Contacto? propietario = null, Contacto? inquilino = null)
        {
            Resumen = resumen;
            CantidadDeAmbientes = cantidadDeAmbientes;
            CantidadDeDormitorios = cantidadDeDormitorios;
            CantidadDeBaños = cantidadDeBaños;
            MetrosCuadrados = metrosCuadrados;
            MetrosCuadradosCubiertos = metrosCuadradosCubiertos;
            Inquilino = inquilino;
            if(!(propietario is null))
                CambiarPropietario(propietario, "Propietario al momento de creación");
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

        public void CambiarPropietario(Contacto nuevoPropietario, string motivoCambio)
        {
            if (!(ContratoActivo is null))
                throw new DominioException("No se puede cambiar el propietario con un contrato en vigencia");

            if (!(Propietario is null))
                HistorialPropietarios.Last().MotivoSalida = motivoCambio;

            var historico = new PropietarioHistorico(nuevoPropietario, motivoCambio);
            HistorialPropietarios.Add(historico);
        }
    }

    public class PropietarioHistorico
    {
        public Contacto Propietario { get; set; }
        public string MotivoEntrada { get; set; }
        public string? MotivoSalida { get; set; }

        public PropietarioHistorico(Contacto propietario, string motivoEntrada)
        {
            Propietario = propietario;
            MotivoEntrada = motivoEntrada;
        }
    }
}