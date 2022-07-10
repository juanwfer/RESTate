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
            var contacto = new Contacto(nombreCompleto:"Juan", telefonoPrincipal:"(123) 456-789");

            Assert.Equal("Juan", contacto.NombreCompleto);
            Assert.Equal("(123) 456-789", contacto.Telefonos.First());
            Assert.Equal("(123) 456-789", contacto.TelefonoPrincipal);
        }

        [Fact]
        public void Contacto_DeberiaCrearse_ConVariosTelefonos()
        {
            var contacto = new Contacto(nombreCompleto: "Juan", telefonos: new List<string> { "123", "456" });

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
    }
}
