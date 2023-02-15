namespace Cadastros.Application.Contracts
{
    public interface IFiltro<DTO> where DTO : class
    {
        public DTO? Dado();
    }
}