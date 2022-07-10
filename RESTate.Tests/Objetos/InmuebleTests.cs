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
                metrosCuadradosCubiertos: 1);
        }

        [Fact]
        public void Inmueble_DeberiaPoderCrearse_ConPropietario()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 2, 1, contacto);
        }

        [Fact]
        public void Inmueble_DeberiaPoderCrearse_ConInquilino()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 2, 1, inquilino: contacto);
        }

        [Fact]
        public void Inmueble_DeberiaPoderReservarse_QuedaReservado()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.NotNull(inmueble.ReservaActiva);
        }

        [Fact]
        public void Inmueble_AlReservarse_ReservaEsDeContactoInteresado()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.Equal(contacto, inmueble.ReservaActiva.Interesado);
        }

        [Fact]
        public void Inmueble_AlReservarse_QuedaFechaDeInicio()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            var fechaInicio = DateTime.Now;

            inmueble.Reservar(contacto, fechaInicio);

            Assert.Equal(fechaInicio, inmueble.ReservaActiva.FechaInicio);
        }

        [Fact]
        public void Inmueble_Reservado_NoPuedeVolverAReservarse()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.Throws<DominioException>(() => inmueble.Reservar(contacto, DateTime.Now));
        }

        [Fact]
        public void InmuebleReservado_PuedeCancelarReserva_QuedaLiberado()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            const string motivoLiberacion = "fue reservado por error";
            DateTime fechaLiberacion = DateTime.Now;

            inmueble.Reservar(contacto, DateTime.Now);
            Reserva copiaReserva = inmueble.ReservaActiva;

            inmueble.LiberarReserva(fechaLiberacion, motivoLiberacion);

            Assert.Null(inmueble.ReservaActiva);
            Assert.Equal(motivoLiberacion, copiaReserva.MotivoLiberacion);
            Assert.Equal(fechaLiberacion, copiaReserva.FechaLiberacion);
        }

        [Fact]
        public void Inmueble_AlReservarse_DuracionPorDefectoEsDeSieteDias()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now);

            Assert.Equal(TimeSpan.FromDays(7), inmueble.ReservaActiva.Duracion);
        }

        [Fact]
        public void Inmueble_PuedeReservarse_PorMasOMenosDias()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now, TimeSpan.FromDays(5));

            Assert.Equal(TimeSpan.FromDays(5), inmueble.ReservaActiva.Duracion);
        }

        [Fact]
        public void Inmueble_Reservado_FechaFinalizacionEsCorrecta()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            var fechaInicio = DateTime.Now;
            var duracion = TimeSpan.FromDays(15);

            inmueble.Reservar(contacto, fechaInicio, duracion);

            Assert.Equal(fechaInicio+duracion, inmueble.ReservaActiva.FechaVencimiento);
        }

        [Fact]
        public void Inmueble_GuardaHistorial_Reservas()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now, TimeSpan.FromDays(5));
            var copiaReserva = inmueble.ReservaActiva;

            inmueble.LiberarReserva(DateTime.Now, "porque sí");

            Assert.Null(inmueble.ReservaActiva);
            Assert.Equal(copiaReserva, inmueble.HistorialReservas.First());
        }

        [Fact]
        public void Inmueble_Reserva_CumpleVencimiento()
        {
            var contacto = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 60, 60, propietario);

            inmueble.Reservar(contacto, DateTime.Now.AddDays(-6), TimeSpan.FromDays(5));
            var copiaReserva = inmueble.ReservaActiva;

            Assert.Null(inmueble.ReservaActiva);
        }
    }
}
