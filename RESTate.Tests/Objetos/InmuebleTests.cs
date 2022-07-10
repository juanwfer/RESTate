using RESTate.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RESTate.Tests.Objetos
{
    public class InmuebleTests
    {
        [Fact]
        public void Inmueble_DeberiaCrearse_ConDatosBasicos()
        {
            var inmueble = new Inmueble(resumen: "Depto",
                cantidadDeAmbientes: 3,
                cantidadDeDormitorios: 1,
                cantidadDeBaños: 2,
                metrosCuadrados: 2,
                metrosCuadradosCubiertos: 1,
                DateTime.Now);
        }

        [Fact]
        public void Inmueble_DeberiaPoderCrearse_ConPropietario()
        {
            var contacto = new Contacto("Juan", "123");
            new Inmueble("Depto", 3, 1, 2, 2, 1,DateTime.Now, contacto);
        }

        [Fact]
        public void Inmueble_DeberiaPoderCrearse_ConInquilino()
        {
            var contacto = new Contacto("Juan", "123");
            new Inmueble("Depto", 3, 1, 2, 2, 1,DateTime.Now, inquilino: contacto);
        }

        [Fact]
        public void Inmueble_DeberiaPoderReservarse_QuedaReservado()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.NotNull(inmueble.ReservaActivaALaFecha(DateTime.Now.AddDays(1)));
        }

        [Fact]
        public void Inmueble_AlReservarse_ReservaEsDeContactoInteresado()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = _InmueblePorDefecto();

            DateTime fecha = DateTime.Now;

            inmueble.Reservar(contacto, fecha);

            Assert.Equal(contacto, inmueble.ReservaActivaALaFecha(fecha).Interesado);
        }

        [Fact]
        public void Inmueble_AlReservarse_QuedaFechaDeInicio()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = _InmueblePorDefecto();

            var fechaInicio = DateTime.Now;

            inmueble.Reservar(contacto, fechaInicio);

            Assert.Equal(fechaInicio, inmueble.ReservaActivaALaFecha(fechaInicio).FechaInicio);
        }

        [Fact]
        public void Inmueble_Reservado_NoPuedeVolverAReservarse()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.Throws<DominioException>(() => inmueble.Reservar(contacto, DateTime.Now));
        }

        [Fact]
        public void InmuebleReservado_PuedeCancelarReserva_QuedaLiberado()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = _InmueblePorDefecto();

            const string motivoLiberacion = "fue reservado por error";

            inmueble.Reservar(contacto, DateTime.Now);
            Reserva copiaReserva = inmueble.ReservaActivaALaFecha(DateTime.Now);

            DateTime fechaLiberacion = DateTime.Now;

            inmueble.LiberarReserva(fechaLiberacion, motivoLiberacion);

            Assert.Null(inmueble.ReservaActivaALaFecha(DateTime.Now));
            Assert.Equal(motivoLiberacion, copiaReserva.MotivoLiberacion);
            Assert.Equal(fechaLiberacion, copiaReserva.FechaLiberacion);
        }

        [Fact]
        public void Inmueble_ReservaNoEntraEnEfecto_AntesDeInicio()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now.AddDays(1));

            Assert.Null(inmueble.ReservaActivaALaFecha(DateTime.Now));
        }

        [Fact]
        public void Inmueble_AlReservarse_DuracionPorDefectoEsDeSieteDias()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.Equal(TimeSpan.FromDays(7), inmueble.ReservaActivaALaFecha(DateTime.Now).Duracion);
        }

        [Fact]
        public void Inmueble_PuedeReservarse_PorMasOMenosDias()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now, TimeSpan.FromDays(5));

            Assert.Equal(TimeSpan.FromDays(5), inmueble.ReservaActivaALaFecha(DateTime.Now).Duracion);
        }

        [Fact]
        public void Inmueble_Reservado_FechaFinalizacionEsCorrecta()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = _InmueblePorDefecto();

            var fechaInicio = DateTime.Now;
            var duracion = TimeSpan.FromDays(15);

            inmueble.Reservar(contacto, fechaInicio, duracion);

            Assert.Equal(fechaInicio+duracion, inmueble.ReservaActivaALaFecha(DateTime.Now).FechaVencimiento);
        }

        [Fact]
        public void Inmueble_GuardaHistorial_Reservas()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now, TimeSpan.FromDays(5));
            var copiaReserva = inmueble.ReservaActivaALaFecha(DateTime.Now);

            inmueble.LiberarReserva(DateTime.Now, "porque sí");

            Assert.Null(inmueble.ReservaActivaALaFecha(DateTime.Now));
            Assert.Equal(copiaReserva, inmueble.HistorialReservas.First());
        }

        [Fact]
        public void Inmueble_Reserva_CumpleVencimiento()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = _InmueblePorDefecto();

            inmueble.Reservar(contacto, DateTime.Now.AddDays(-6), TimeSpan.FromDays(5));

            Assert.Null(inmueble.ReservaActivaALaFecha(DateTime.Now));
        }

        [Fact]
        public void Inmueble_PuedeAgregarsePropietarioDespuesDeCreacion()
        {
            var nuevoPropietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, DateTime.Now);

            inmueble.CambiarPropietario(nuevoPropietario, "motivoDeCambio", DateTime.Now);

            Assert.Equal(nuevoPropietario, inmueble.Propietario);
        }

        [Fact]
        public void Inmueble_RegistraHistorialPropietarios()
        {
            var p1 = new Contacto("Jorge", "123");

            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, DateTime.Now, p1);

            Assert.Equal(p1, inmueble.HistorialPropietarios.First().Propietario);
        }

        [Fact]
        public void Inmueble_PropietarioActual_EsUltimoPropietario()
        {
            var p1 = new Contacto("Jorge", "123");
            var p2 = new Contacto("Martín", "987");

            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60,DateTime.Now, p1);

            inmueble.CambiarPropietario(p2, "segundo propietario", DateTime.Now);

            Assert.Equal(p2, inmueble.Propietario);
        }

        [Fact]
        public void Inmueble_HistorialPropietarios_GuardaMotivoSalida()
        {
            var p1 = new Contacto("Jorge", "123");
            var p2 = new Contacto("Martín", "3243234");

            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, DateTime.Now, p1);
            const string motivoCambio = "SegundoPropietario";

            inmueble.CambiarPropietario(p2, motivoCambio, DateTime.Now);

            Assert.Equal(p2, inmueble.HistorialPropietarios.Last().Propietario);
            Assert.Equal(motivoCambio, inmueble.HistorialPropietarios.Last().MotivoEntrada);
            Assert.Equal(motivoCambio, inmueble.HistorialPropietarios.First().MotivoSalida);
        }

        [Fact]
        public void Inmueble_ConContratoDeAlquiler_NoPuedeCambiarPropietario()
        {
            var propietario = new Contacto("Jorge", "123");
            var inquilino = new Contacto("Martín", "3243234");
            var propietario2 = new Contacto("Pedro", "225265");

            var inmueble = _InmueblePorDefecto();

            var contratoAlquiler = new ContratoAlquiler(inmueble, inquilino);

            contratoAlquiler.EstablecerPlazo(DateTime.Now, DateTime.Now.AddMonths(12));
            contratoAlquiler.EstablecerMontoPactado(50000, DateTime.Now);

            contratoAlquiler.Firmar(DateTime.Now);

            const string motivoCambio = "SegundoPropietario";

            Assert.Throws<DominioException>(() => inmueble.CambiarPropietario(propietario2, motivoCambio, DateTime.Now));
        }

        [Fact]
        public void Inmueble_ConContratoDeAlquilerRescindido_PuedeCambiarPropietario()
        {
            var propietario = new Contacto("Jorge", "123");
            var inquilino = new Contacto("Martín", "3243234");
            var propietario2 = new Contacto("Pedro", "225265");

            var inmueble = _InmueblePorDefecto();

            var contratoAlquiler = new ContratoAlquiler(inmueble, inquilino);

            contratoAlquiler.EstablecerPlazo(DateTime.Now, DateTime.Now.AddMonths(12));
            contratoAlquiler.EstablecerMontoPactado(50000, DateTime.Now);

            contratoAlquiler.Firmar(DateTime.Now);

            contratoAlquiler.Rescindir(DateTime.Now, "por cambio de propietario");

            const string motivoCambio = "SegundoPropietario";

            inmueble.CambiarPropietario(propietario2, motivoCambio, DateTime.Now);
        }

        [Fact]
        public void Inmueble_DeberiaTener_MasCaracteristicas()
        {
            var inmueble = _InmueblePorDefecto();

            inmueble.Descripcion = "Este inmueble cuenta con dos baños";
        }

        private Inmueble _InmueblePorDefecto()
        {
            var propietario = new Contacto("Matias", "456");
            return new Inmueble("Depto", 3, 1, 2, 60, 60, DateTime.Now, propietario);
        }
    }
}
