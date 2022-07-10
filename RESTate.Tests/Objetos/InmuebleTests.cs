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

        public void Inmueble_DeberiaPoderCrearse_ConInquilino()
        {
            var contacto = new Contacto("Juan", "123");
            var inmueble = new Inmueble("Depto", 3, 1, 2, 2, 1, inquilino: contacto);
        }
    }
}
