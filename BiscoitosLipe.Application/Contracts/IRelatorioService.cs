namespace Cadastros.Application.Contracts
{
    public interface IRelatorioService<DTO> where DTO : class
    {
        Task<List<DTO>> Get(int page, int pageSize);
        Task<List<DTO>> GetFiltro(IFiltro<DTO>? filtro,
            int page, int pageSize);
    }
}