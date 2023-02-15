using AutoMapper;
using BiscoitosLipe.Application.Contracts;
using BiscoitosLipe.Application.DTO;
using BiscoitosLipe.Application.Utils;
using BiscoitosLipe.Domain;
using BiscoitosLipe.Persistence.Contracts;

namespace BiscoitosLipe.Application.Services.Comandos
{
    public class CadastroService : ICadastroService
    {
        private IPersistenciaDinamica<Clientes> PersistenciaClientes;
        private IPersistenciaDinamica<Localizacao> PersistenciaLocalizacao;
        private IPersistenciaDinamica<Pedidos> PersistenciaPedidos;
        private IPersistenciaEstatica<Localizacao> ConsultaLocalizacao;
        private IPersistenciaEstatica<Pedidos> ConsultaPedidos;
        private IPersistenciaEstatica<Clientes> ConsultaClientes;
        private IMapper Mapper;

        public CadastroService(IPersistenciaDinamica<Clientes> persistenciaClientes, IPersistenciaDinamica<Localizacao> persistenciaLocalizacao,
            IPersistenciaDinamica<Pedidos> persistenciaPedidos, IPersistenciaEstatica<Localizacao> consultaLocalizacao, 
            IPersistenciaEstatica<Pedidos> consultaPedidos, IPersistenciaEstatica<Clientes> consultaClientes, IMapper mapper)
        {
            this.PersistenciaClientes = persistenciaClientes;
            this.PersistenciaLocalizacao = persistenciaLocalizacao;
            this.PersistenciaPedidos = persistenciaPedidos;
            this.ConsultaLocalizacao = consultaLocalizacao;
            this.ConsultaPedidos = consultaPedidos;
            this.ConsultaClientes = consultaClientes;
            this.Mapper = mapper;
        }

        public async Task<List<ClienteDTO>> PostClientes(List<ClienteDTO> dto)
        {
            foreach (ClienteDTO model in dto)
            {
                List<LocalizacaoDTO> listLocalizacaoDTO = new() { model.Localizacao};
                List<Localizacao> listLocalizacao = Conversor<Localizacao, LocalizacaoDTO>.ConverteParaD(listLocalizacaoDTO, Mapper);
                await PersistenciaLocalizacao.PostAsync(listLocalizacao);
            }

            List<Clientes> modelList = Conversor<Clientes, ClienteDTO>.ConverteParaD(dto, Mapper);

            foreach (Clientes model in modelList)
            {
                model.IdLocalização = dto.First().Localizacao.Id;
            }
            
            return Conversor<Clientes, ClienteDTO>.ConverteParaDTO(await PersistenciaClientes.PostAsync(modelList), Mapper);
        }
    }
}
