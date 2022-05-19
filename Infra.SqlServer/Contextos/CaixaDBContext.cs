using Infra.SqlServer.Modelos.Caixas;
using Microsoft.EntityFrameworkCore;

namespace Infra.SqlServer.Modelos
{
    public sealed class CaixaDBContext : DbContext
    {
        public DbSet<CaixaDB> Caixas { get; set; }
        public DbSet<MovimentoDB> Movimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Faturamento;Trusted_Connection=True;");
        }
    }
}
