namespace BiscoitosLipe.Domain
{
    public class Pedidos
    {
        public Pedidos(string id, string idCliente)
        {
            Id = id;
            IdCliente = idCliente;
        }

        public string Id { get; set; }
        public string IdCliente { get; set; }
    }
}