using AutoMapper;
using Cadastros.Application.Contracts;
using Cadastros.Application.Filters;
using Cadastros.Application.Utils;
using Cadastros.Persistence.Contracts;
using System.Linq.Expressions;

namespace Cadastros.Application.Services.Consultas
{
    public class RelatorioContaService<D, DTO> : IRelatorioService<DTO>
        where D : class
        where DTO : class
    {
        private IPersistenciaEstatica<D> PersistenciaConta;
        private readonly IMapper Mapper;
        public RelatorioContaService(IPersistenciaEstatica<D> persistenciaConta, IMapper mapper)
        {
            this.PersistenciaConta = persistenciaConta;
            this.Mapper = mapper;
        }

        public async Task<List<DTO>> Get(int page, int pageSize)
        {
            return Conversor<D, DTO>.ConverteParaListaDTO(await PersistenciaConta.GetAsync(page, pageSize), Mapper);
        }

        public async Task<List<DTO>> GetFiltro(IFiltro<DTO>? filtro,
            int page, int pageSize)
        {
            Expression<Func<D, bool>>? expressao = ConstroiIFiltro<DTO, D>.GetFiltro(filtro?.Dado());
            return Conversor<D, DTO>.ConverteParaListaDTO(
                await PersistenciaConta.GetFiltroAsync(expressao, page, pageSize), Mapper);
        }
    }
}