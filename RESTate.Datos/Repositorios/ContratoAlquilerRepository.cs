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
    public interface IContratoAlquilerRepository
    {
        public Task<IEnumerable<ContratoAlquiler>> FindAsync(Expression<Func<ContratoAlquiler, bool>> predicate, Func<IQueryable<ContratoAlquiler>, IIncludableQueryable<ContratoAlquiler, object>>? include = null);
    }

    public class ContratoAlquilerRepository : Repositorio, IContratoAlquilerRepository
    {
        public ContratoAlquilerRepository(RESTateContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContratoAlquiler>> FindAsync(Expression<Func<ContratoAlquiler, bool>> predicate, Func<IQueryable<ContratoAlquiler>, IIncludableQueryable<ContratoAlquiler, object>>? include = null)
        {
            IQueryable<ContratoAlquiler> query = _context.ContratosAlquiler.Where(predicate);

            if (include != null)
                return await include(query).ToListAsync();

            return await query.ToListAsync();
        }
    }
}
