using Faturamento.Definicoes;
using MediatR;
using System;

namespace Faturamento.Dominio.ServicosDeDominio.Transferencias
{
    public sealed class EfetuarTransferenciaComando : IRequest<Resultado<bool>>
    {
        public EfetuarTransferenciaComando(Guid caixaOrigemId, Guid caixaDestinoId, decimal valor, string descricao, Guid operadorId)
        {
            CaixaOrigemId = caixaOrigemId;
            CaixaDestinoId = caixaDestinoId;
            Valor = valor;
            Descricao = descricao;
            OperadorId = operadorId;
        }

        public Guid CaixaOrigemId { get; }
        public Guid CaixaDestinoId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
        public Guid OperadorId { get; }
    }
}
