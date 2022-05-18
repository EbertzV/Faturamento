using System;

namespace Faturamento.Dominio.Recebimentos
{
    public sealed class EfetuarRecebimentoComando
    {
        public Guid CaixaId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
    }
}
