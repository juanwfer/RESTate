using RESTate.Objetos.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Objetos
{
    public class Garantia
    {
        public TipoGarantia Tipo { get; set; }
        public string? Descripcion { get; set; }

        public Garantia(TipoGarantia tipo, string? descripcion = null)
        {
            Tipo = tipo;
            Descripcion = descripcion;
        }
    }
}
