using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;
using System;

namespace Faturamento.Dominio.Operacoes
{
    public sealed class Transferencia
    {
        public Transferencia(Guid id, Caixa caixaOrigem, Caixa caixaDestino)
        {
            Id = id;
            CaixaOrigem = caixaOrigem;
            CaixaDestino = caixaDestino;
        }

        public static Transferencia Nova(Caixa caixaOrigem, Caixa caixaDestino)
            => new Transferencia(Guid.NewGuid(), caixaOrigem, caixaDestino);

        public Transferencia Efetuar(decimal valor, DateTime quando, string descricao = "")
            => Pagar(valor, quando, descricao).Receber(valor, quando, descricao);

        private Transferencia Receber(decimal valor, DateTime quando, string descricao)
        {
            CaixaDestino.AdicionarValor(valor);
            MovimentoEntrada = Movimento.NovoDeEntrada(valor, quando, descricao);
            return this;
        }

        private Transferencia Pagar(decimal valor, DateTime quando, string descricao)
        {
            CaixaOrigem.SubtrairValor(valor);
            MovimentoSaida = Movimento.NovoDeSaida(valor, quando, descricao);
            return this;
        }

        public Guid Id { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
        public Caixa CaixaOrigem { get; }
        public Caixa CaixaDestino { get; }
        public Movimento MovimentoEntrada { get; private set; }
        public Movimento MovimentoSaida { get; private set; }
    }
}
