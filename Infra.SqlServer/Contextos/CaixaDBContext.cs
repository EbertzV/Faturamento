using Infra.SqlServer.Modelos.Caixas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.SqlServer.Modelos
{
    public sealed class CaixaDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CaixaDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<CaixaDB> Caixas { get; set; }
        public DbSet<MovimentoDB> Movimentos { get; set; }
        public DbSet<OperacaoDB> Operacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }
    }
}
