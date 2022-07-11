using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RESTate.Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTate.Datos.Repositorios
{
    public interface IContactoRepository
    {
        public Task<IEnumerable<Contacto>> FindAsync(Expression<Func<Contacto, bool>> predicate, Func<IQueryable<Contacto>, IIncludableQueryable<Contacto, object>>? include = null);
    }

    public class ContactoRepository : Repositorio, IContactoRepository
    {
        public ContactoRepository(RESTateContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Contacto>> FindAsync(Expression<Func<Contacto, bool>> predicate, Func<IQueryable<Contacto>, IIncludableQueryable<Contacto, object>>? include = null)
        {
            IQueryable<Contacto> query = _context.Contactos.Where(predicate);

            if (include != null)
                return await include(query).ToListAsync();

            return await query.ToListAsync();
        }
    }
}
