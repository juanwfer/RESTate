using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RESTate.Objetos;
using RESTate.Objetos.Enums;

namespace RESTate.Tests.Objetos
{
    public class GarantiaTests
    {
        [Fact]
        public void Garantia_DeberiaPoderCrearse_ConDatosBasicos()
        {
            var garantia = new Garantia(TipoGarantia.Propietaria, "Descripcion");
        }

        [Fact]
        public void Garantia_DeberiaPoderCrearse_SinDescripcion()
        {
            var garantia = new Garantia(TipoGarantia.Garante);
        }
    }
}
