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
            new ContratoAlquiler(inmueble, propietario, inquilino);
        }

        [Fact]
        public void ContratoAlquiler_NoDeberiaCrearse_ParaInmuebleReservado()
        {
            var interesado = new Contacto("Jorge", "123");
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            inmueble.Reservar(interesado, DateTime.Now.AddDays(-6));

            Assert.Throws<DominioException>(() => new ContratoAlquiler(inmueble, propietario, inquilino));
        }

        [Fact]
        public void ContratoAlquiler_DeberiaPoderHacerse_SiInquilinoEsQuienReserva()
        {
            var interesadoEInquilino = new Contacto("Jorge", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            inmueble.Reservar(interesadoEInquilino, DateTime.Now.AddDays(-6));

            var contrato = new ContratoAlquiler(inmueble, propietario, interesadoEInquilino);
        }

        [Fact]
        public void ContratoAlquiler_DeberiaGuardarse_EnHistorialDeInmueble()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, propietario, inquilino);
        }

        [Fact]
        public void ContratoAlquiler_ComienzaNoVigente()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, propietario, inquilino);

            Assert.False(contrato.Vigente);
        }

        [Fact]
        public void ContratoAlquiler_NoPuedeFirmarse_HastaEstarCompleto()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, propietario, inquilino);

            Assert.Throws<DominioException>(() => contrato.Firmar(DateTime.Now));
        }

        [Fact]
        public void ContratoAlquiler_PuedeFirmarse_ConDatosObligatorios()
        {
            var inquilino = new Contacto("Juan", "123");
            var propietario = new Contacto("Matias", "456");
            var inmueble = new Inmueble("Departamento", 3, 1, 1, 60, 60, propietario);

            var contrato = new ContratoAlquiler(inmueble, propietario, inquilino);

            contrato.EstablecerPlazo(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(2 + 12*3));
            contrato.MontoPactadoInicial = 50000;
            contrato.UbicacionDocumento = "contrato.pdf";

            var fechaFirma = DateTime.Now;

            contrato.Firmar(fechaFirma);
            Assert.Equal(fechaFirma, contrato.FechaFirma);
        }
    }
}
