using RESTate.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RESTate.Tests.Objetos
{
    public class ContactoTests
    {
        [Fact]
        public void Contacto_DeberiaCrearse_ConNombreCompletoYContacto()
        {
            var contacto = new Contacto(nombreCompleto:"Juan", telefonos:"(123) 456-789");

            Assert.Equal("Juan", contacto.NombreCompleto);
            Assert.Equal("(123) 456-789", contacto.Telefonos.First());
            Assert.Equal("(123) 456-789", contacto.TelefonoPrincipal);
        }

        [Fact]
        public void Contacto_DeberiaCrearse_ConVariosTelefonos()
        {
            var contacto = new Contacto(nombreCompleto: "Juan", "123", "456");

            Assert.Equal("Juan", contacto.NombreCompleto);
            Assert.Equal("123", contacto.TelefonoPrincipal);
            Assert.Equal("123", contacto.Telefonos.First());
            Assert.Equal("456", contacto.Telefonos[1]);
        }

        [Theory]
        [InlineData("Juan\n")]
        [InlineData("Juan\t")]
        [InlineData("Juan\r")]
        [InlineData("Juan ")]
        [InlineData(" Juan")]
        [InlineData("  Juan\r")]
        [InlineData("  Juan  ")]
        public void Contacto_NombreDeberiaSerTrimmeado(string nombreCompleto)
        {
            var contacto = new Contacto(nombreCompleto, "123");
            Assert.Equal("Juan", contacto.NombreCompleto);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Contacto_NombreNoDeberiaSerEspacioOVacio(string nombreCompleto)
        {
            Assert.Throws<ArgumentException>(() => new Contacto(nombreCompleto, "123"));
        }

        [Fact]
        public void Contacto_NombreNoDeberiaSerNulo()
        {
            Assert.Throws<ArgumentNullException>(() => new Contacto(null, "123"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void Contacto_TelefonoNoDeberiaSerEspacioOVacio(string telefono)
        {
            Assert.Throws<ArgumentException>(() => new Contacto("Juan", telefono));
        }

        [Fact]
        public void Contacto_TelefonoNoDeberiaSerNulo()
        {
            Assert.Throws<ArgumentNullException>(() => new Contacto("Juan", null));
        }

        [Fact]
        public void Contacto_DeberiaTenerAlMenosUnTelefono()
        {
            Assert.Throws<ArgumentException>(() => new Contacto("Juan"));
        }
    }
}
