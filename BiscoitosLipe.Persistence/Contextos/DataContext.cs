using BiscoitosLipe.Domain;
using BiscoitosLipe.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BiscoitosLipe.Persistence.Contextos

{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Clientes> Pessoas { get; set; }
    }
}