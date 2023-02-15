

using BiscoitosLipe.Application.DTO;

namespace BiscoitosLipe.Application.Contracts
{
    public interface ICadastroService
    {
        public Task<List<ClienteDTO>> PostClientes(List<ClienteDTO> dto);
    }
}