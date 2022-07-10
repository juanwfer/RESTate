using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RESTate.Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RESTate.Datos.Repositorios
{
    public interface IInmuebleRepository
    {
        public Task<IEnumerable<Inmueble>> FindAsync(Expression<Func<Inmueble, bool>> predicate, Func<IQueryable<Inmueble>, IIncludableQueryable<Inmueble, object>>? include = null);
    }

    public class InmuebleRepository : Repositorio, IInmuebleRepository
    {
        public InmuebleRepository(RESTateContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Inmueble>> FindAsync(Expression<Func<Inmueble, bool>> predicate, Func<IQueryable<Inmueble>, IIncludableQueryable<Inmueble, object>>? include = null)
        {
            IQueryable<Inmueble> query = _context.Inmuebles.Where(predicate);

            if (include != null)
                return await include(query).ToListAsync();

            return await query.ToListAsync();
        }
    }
}
