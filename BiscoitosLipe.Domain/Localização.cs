namespace BiscoitosLipe.Domain
{
    public class Localização
    {
        public Localização(string cidade, string estado, string cep, string rua, string bairro, string numero)
        {
            Id = Guid.NewGuid().ToString("n");
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public string Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set;}
        public string Bairro { get; set;}
        public string Numero { get; set;}
    }
}