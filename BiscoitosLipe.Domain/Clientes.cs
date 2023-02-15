namespace BiscoitosLipe.Domain
{
    public class Clientes
    {
        public Clientes(string nome, string idLocalização, List<Pedidos> pedidos)
        {
            Id = Guid.NewGuid().ToString("n");
            Nome = nome;
            IdLocalização = idLocalização;
            Pedidos = pedidos;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string IdLocalização { get; set; }
        public List<Pedidos> Pedidos { get; set; }


    }
}