using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;
using System;

namespace Faturamento.Dominio.Operacoes
{
    public sealed class Recebimento
    {
        public Recebimento(Caixa caixa, Guid id)
        {
            Caixa = caixa;
            Id = id;
        }

        public void Efetuar(decimal valor, string descricao, DateTime quando)
        {
            Caixa.AdicionarValor(valor);
            Movimento = Movimento.NovoDeEntrada(valor, quando, descricao);
        }

        public Guid Id { get; }
        public Caixa Caixa { get; }
        public Movimento Movimento { get; private set; }
    }
}
