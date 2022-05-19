using System;

namespace Infra.SqlServer.Modelos.Caixas
{
    public sealed class CaixaDB
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal SaldoAtual { get; set; }
        public string Status { get; set; }
    }
}
