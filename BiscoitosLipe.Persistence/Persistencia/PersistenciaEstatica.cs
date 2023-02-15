using BiscoitosLipe.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BiscoitosLipe.Persistence.Persistencia
{
    public class PersistenciaEstatica<D> : IPersistenciaEstatica<D> where D : class
    {
        private IDataContext Ctx;
        private DbSet<D>? DbSet;
        public PersistenciaEstatica(IDataContext ctx)
        {
            this.Ctx = ctx;
            this.DbSet = this.Ctx != null ? this.Ctx.Set<D>() : throw new ArgumentNullException("DbSet nulo");
        }

        public async Task<List<D>> GetFiltroAsync(Expression<Func<D, bool>> expressaoDeConsulta,
            int page, int pageSize)
        {
            return await this.DbSet.Where(expressaoDeConsulta).Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<D>> GetAsync(int page, int pageSize)
        {
            return await this.DbSet.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }
    }
}