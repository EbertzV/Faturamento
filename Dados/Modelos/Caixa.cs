using System;

namespace Dados.Modelos
{
    public sealed class Caixa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal SaldoAtual { get; set; }
        public string Status { get; set; }
    }
}
