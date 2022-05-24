using Faturamento.Definicoes;
using MediatR;
using System;

namespace Faturamento.Dominio.Recebimentos
{
    public sealed class EfetuarRecebimentoComando : IRequest<Resultado<bool>>
    {
        public EfetuarRecebimentoComando(Guid caixaId, decimal valor, string descricao, Guid operadorId)
        {
            CaixaId = caixaId;
            Valor = valor;
            Descricao = descricao;
            OperadorId = operadorId;
        }

        public Guid CaixaId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
        public Guid OperadorId { get; }
    }
}
