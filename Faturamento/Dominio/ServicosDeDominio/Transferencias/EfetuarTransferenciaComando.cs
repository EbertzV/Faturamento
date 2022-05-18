using System;

namespace Faturamento.Dominio.ServicosDeDominio.Transferencias
{
    public sealed class EfetuarTransferenciaComando
    {
        public EfetuarTransferenciaComando(Guid caixaOrigemId, Guid caixaDestinoId, decimal valor, string descricao)
        {
            CaixaOrigemId = caixaOrigemId;
            CaixaDestinoId = caixaDestinoId;
            Valor = valor;
            Descricao = descricao;
        }

        public Guid CaixaOrigemId { get; }
        public Guid CaixaDestinoId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
    }
}
