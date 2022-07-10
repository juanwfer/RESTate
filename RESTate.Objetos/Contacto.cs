using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RESTate.Objetos
{
    public class Contacto
    {
        public string NombreCompleto { get; set; }
        public string TelefonoPrincipal { get => Telefonos.First(); }
        public List<string> Telefonos { get; set; }

        public Contacto(string nombreCompleto, string telefonoPrincipal)
        {
            NombreCompleto = nombreCompleto.Trim();
            Telefonos = new List<string> { telefonoPrincipal };
        }

        public Contacto(string nombreCompleto, List<string> telefonos)
        {
            NombreCompleto = nombreCompleto.Trim();
            Telefonos = telefonos;
        }
    }
}
