using BiscoitosLipe.Domain;
using BiscoitosLipe.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BiscoitosLipe.Persistence.Contextos

{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Localização> Localizacao { get; set; }
    }
}