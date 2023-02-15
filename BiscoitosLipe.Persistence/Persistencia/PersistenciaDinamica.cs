using BiscoitosLipe.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cadastros.Persistence.Persistencia
{
    public class PersistenciaDinamica<D> : IPersistenciaDinamica<D> where D : class
    {
        private IDataContext Ctx;
        private DbSet<D>? DbSet;
        public PersistenciaDinamica(IDataContext ctx)
        {
            this.Ctx = ctx;
            this.DbSet = this.Ctx != null ? this.Ctx.Set<D>() : throw new ArgumentNullException("DbSet nulo");
        }

        public async Task<List<D>> PostAsync(List<D> modelList)
        {
            if (modelList == null)
            {
                throw new ArgumentNullException("modelList nulo");
            }
            else
            {
                foreach (D model in modelList)
                {
                    this.DbSet.Add(model);
                }
                await this.Ctx.SaveChangesAsync();
                return modelList;
            }
        }
    }
}