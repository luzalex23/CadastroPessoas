using CadastroPessoas.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Pessoas> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server = localhost;" +
                "Port = 5433;Database=developer;" +
                "User Id=postgres;" +
                "Password=root12345;");
   

    }
}
