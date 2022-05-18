using System;

namespace Faturamento.Dominio.ServicosDeDominio.Pagamentos
{
    public sealed class EfetuarPagamentoComando
    {
        public Guid CaixaId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
    }
}