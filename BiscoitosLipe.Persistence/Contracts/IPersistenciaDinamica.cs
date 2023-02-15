namespace BiscoitosLipe.Persistence.Contracts
{
    public interface IPersistenciaDinamica<D> where D : class
    {
        public Task<List<D>> PostAsync(List<D> model);
    }
}