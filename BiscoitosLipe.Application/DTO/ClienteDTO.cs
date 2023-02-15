using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscoitosLipe.Application.DTO
{
    public class ClienteDTO
    {
        public ClienteDTO(string nome, LocalizacaoDTO localizacao)
        {
            Nome = nome;
            Localizacao = localizacao;
        }

        public string Nome { get; set; }
        public LocalizacaoDTO Localizacao{ get; set; } 
    }
}
