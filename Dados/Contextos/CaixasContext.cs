using Dados.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class CaixasContext : DbContext
    {
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Faturamento;Trusted_Connection=True;");
        }
    }
}
