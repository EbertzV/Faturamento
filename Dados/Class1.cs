using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dados
{
    public class CaixasContext : DbContext
    {
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }

        //Server=localhost;Database=Faturamento;Trusted_Connection=True;
    }
}
