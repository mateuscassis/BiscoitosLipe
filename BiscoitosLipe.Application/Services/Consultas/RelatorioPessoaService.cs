using AutoMapper;
using Cadastros.Application.Contracts;
using Cadastros.Application.Filters;
using Cadastros.Application.Utils;
using Cadastros.Persistence.Contracts;
using System.Linq.Expressions;

namespace Cadastros.Application.Services.Consultas
{
    public class RelatorioPessoaService<D, DTO> : IRelatorioService<DTO>
        where D : class
        where DTO : class
    {
        private IPersistenciaEstatica<D> PersistenciaPessoa;
        private readonly IMapper Mapper;
        public RelatorioPessoaService(IPersistenciaEstatica<D> persistenciaPessoa, IMapper mapper)
        {
            this.PersistenciaPessoa = persistenciaPessoa;
            this.Mapper = mapper;
        }

        public async Task<List<DTO>> Get(int page, int pageSize)
        {
            return Conversor<D, DTO>.ConverteParaListaDTO(await PersistenciaPessoa.GetAsync(page, pageSize), Mapper);
        }

        public async Task<List<DTO>> GetFiltro(IFiltro<DTO>? filtro,
            int page, int pageSize)
        {
            Expression<Func<D, bool>>? expressao = ConstroiIFiltro<DTO, D>.GetFiltro(filtro?.Dado());
            return Conversor<D, DTO>.ConverteParaDTO(await PersistenciaPessoa.GetFiltroAsync(expressao, page, pageSize), Mapper);
        }
    }
}