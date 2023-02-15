using System.Linq.Expressions;

namespace BiscoitosLipe.Persistence.Contracts
{
    public interface IPersistenciaEstatica<D>
    {
        Task<List<D>> GetAsync(int page, int pageSize);
        Task<List<D>> GetFiltroAsync(Expression<Func<D, bool>> expressaoDeConsulta,
            int page, int pageSize);
    }
}