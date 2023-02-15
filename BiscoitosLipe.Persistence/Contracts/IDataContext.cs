using BiscoitosLipe.Domain;
using Microsoft.EntityFrameworkCore;

namespace BiscoitosLipe.Persistence.Contracts
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<Clientes> Pessoas { get; set; }
    }
}