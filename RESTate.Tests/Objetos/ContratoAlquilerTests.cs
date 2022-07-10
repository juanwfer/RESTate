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
    }
}
