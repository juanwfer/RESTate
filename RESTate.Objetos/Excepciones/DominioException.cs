using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Objetos
{
    public class DominioException : Exception
    {
        public DominioException(string message) : base(message)
        {
        }
    }
}
