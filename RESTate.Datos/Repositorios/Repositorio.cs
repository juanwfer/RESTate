using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Datos.Repositorios
{
    public class Repositorio
    {
        protected readonly RESTateContext _context;
        public Repositorio(RESTateContext context)
        {
            _context = context;
        }
    }
}
