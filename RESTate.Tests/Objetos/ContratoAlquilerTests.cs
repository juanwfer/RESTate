using RESTate.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RESTate.Tests.Objetos
{
    public class ContratoAlquilerTests
    {
        [Fact]
        public void ContratoAlquiler_DeberiaPoderCrearse_ConTresPartes()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);
            new ContratoAlquiler(inmueble, inquilino);
        }

        [Fact]
        public void ContratoAlquiler_NoDeberiaFirmarse_ParaInmuebleReservado()
        {
            var interesado = new Contacto("Jorge", "123");
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            inmueble.Reservar(interesado, DateTime.Now.AddDays(-6));
            var contrato = new ContratoAlquiler(inmueble, inquilino);
            contrato.EstablecerPlazo(DateTime.Now, DateTime.Now.AddDays(500));
            contrato.EstablecerMontoPactado(50000);

            Assert.Throws<DominioException>(() => contrato.Firmar(DateTime.Now));
        }

        [Fact]
        public void ContratoAlquiler_DeberiaPoderFirmarse_SiInquilinoEsQuienReserva()
        {
            var interesadoEInquilino = new Contacto("Jorge", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            inmueble.Reservar(interesadoEInquilino, DateTime.Now.AddDays(-6));

            var contrato = new ContratoAlquiler(inmueble, interesadoEInquilino);

            contrato.EstablecerPlazo(DateTime.Now, DateTime.Now.AddDays(500));
            contrato.EstablecerMontoPactado(50000);

            contrato.Firmar(DateTime.Now);
        }

        [Fact]
        public void ContratoAlquiler_DeberiaPoderHacerse_SoloSiInmuebleTienePropietario()
        {
            var interesadoEInquilino = new Contacto("Jorge", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60);

            inmueble.Reservar(interesadoEInquilino, DateTime.Now.AddDays(-6));

            Assert.Throws<DominioException>(() => new ContratoAlquiler(inmueble, interesadoEInquilino));
        }

        [Fact]
        public void ContratoAlquiler_DeberiaGuardarse_EnHistorialDeInmueble()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, inquilino);
        }

        [Fact]
        public void ContratoAlquiler_ComienzaNoVigente()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, inquilino);

            Assert.False(contrato.Vigente);
        }

        [Fact]
        public void ContratoAlquiler_NoPuedeFirmarse_HastaEstarCompleto()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, inquilino);

            Assert.Throws<DominioException>(() => contrato.Firmar(DateTime.Now));
        }

        [Fact]
        public void ContratoAlquiler_PuedeFirmarse_ConDatosObligatorios()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, inquilino);

            contrato.EstablecerPlazo(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(2 + 12*3));
            contrato.EstablecerMontoPactado(50000);
            contrato.UbicacionDocumento = "contrato.pdf";

            var fechaFirma = DateTime.Now;

            contrato.Firmar(fechaFirma);
            Assert.Equal(fechaFirma, contrato.FechaFirma);
        }

        [Fact]
        public void ContratoAlquiler_DespuesDeFirmarse_NoPuedeModificarseMontoPactadoInicial()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, inquilino);

            contrato.EstablecerPlazo(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(2 + 12 * 3));
            contrato.EstablecerMontoPactado(50000);
            contrato.UbicacionDocumento = "contrato.pdf";

            contrato.Firmar(DateTime.Now);

            Assert.Throws<DominioException>(() => contrato.EstablecerMontoPactado(100000));
        }

        [Fact]
        public void ContratoAlquiler_SePuedeRescindir()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, inquilino);

            contrato.EstablecerPlazo(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(2 + 12 * 3));
            contrato.EstablecerMontoPactado(50000);
            contrato.UbicacionDocumento = "contrato.pdf";

            var fechaFirma = DateTime.Now;

            contrato.Firmar(fechaFirma);

            var fechaRescision = DateTime.Now;

            contrato.Rescindir(fechaRescision, motivoRescision: "por fuerza mayor");

            Assert.False(contrato.Vigente);
            Assert.Equal(fechaRescision, contrato.FechaRescision);
        }
    }
}
