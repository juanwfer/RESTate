using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Objetos
{
    public class ContratoAlquiler
    {
        public Inmueble Inmueble { get; }
        public Contacto Propietario { get; }
        public Contacto Inquilino { get; }

        public ContratoAlquiler(Inmueble inmueble, Contacto propietario, Contacto inquilino)
        {
            Inmueble = inmueble;
            Propietario = propietario;
            Inquilino = inquilino;
        }
    }
}
