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
    public interface IReservaRepository
    {
        public Task<IEnumerable<Reserva>> FindAsync(Expression<Func<Reserva, bool>> predicate, Func<IQueryable<Reserva>, IIncludableQueryable<Reserva, object>>? include = null);
    }

    public class ReservaRepository : Repositorio, IReservaRepository
    {
        public ReservaRepository(RESTateContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reserva>> FindAsync(Expression<Func<Reserva, bool>> predicate, Func<IQueryable<Reserva>, IIncludableQueryable<Reserva, object>>? include = null)
        {
            IQueryable<Reserva> query = _context.Reservas.Where(predicate);

            if (include != null)
                return await include(query).ToListAsync();

            return await query.ToListAsync();
        }
    }
}
