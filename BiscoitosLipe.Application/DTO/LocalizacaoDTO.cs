namespace BiscoitosLipe.Application.DTO
{
    public class LocalizacaoDTO
    {
        public LocalizacaoDTO(string cidade, string estado, string cEP, string rua, string bairro, string numero)
        {
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
    }
}