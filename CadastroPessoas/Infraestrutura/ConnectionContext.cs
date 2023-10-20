using CadastroPessoas.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Pessoas> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server = localhost;" +
                "Port = 5432;Database=developer;" +
                "User Id=postegres;" +
                "Password=root12345"

                );
   

    }
}
