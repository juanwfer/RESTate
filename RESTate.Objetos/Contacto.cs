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

        public Contacto(string nombreCompleto, params string[] telefonos)
        {
            if (nombreCompleto is null)
                throw new ArgumentNullException(nameof(nombreCompleto));

            if(telefonos.Any(t => t is null))
                throw new ArgumentNullException(nameof(telefonos));

            if (telefonos.Length == 0)
                throw new ArgumentException("El contacto necesita al menos un teléfono para contactarlo", nameof(telefonos));

            NombreCompleto = nombreCompleto.Trim();

            if (string.IsNullOrWhiteSpace(NombreCompleto))
                throw new ArgumentException("Nombre inválido", nameof(nombreCompleto));

            Telefonos = telefonos.Select(t => t.Trim()).Distinct().ToList();

            if (Telefonos.Any(t => string.IsNullOrEmpty(t)))
                throw new ArgumentException("Teléfono inválido", nameof(telefonos));
        }
    }
}
