using MediatR;
using System;

namespace Faturamento.Dominio.Recebimentos
{
    public sealed class EfetuarRecebimentoComando : IRequest<bool>
    {
        public EfetuarRecebimentoComando(Guid caixaId, decimal valor, string descricao)
        {
            CaixaId = caixaId;
            Valor = valor;
            Descricao = descricao;
        }

        public Guid CaixaId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
    }
}
