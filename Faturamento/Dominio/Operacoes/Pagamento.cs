using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;
using System;

namespace Faturamento.Dominio.Operacoes
{
    public sealed class Pagamento
    {
        public Pagamento(Guid id, Caixa caixa)
        {
            Id = id;
            Caixa = caixa;
        }

        public static Pagamento Novo(Caixa caixa)
            => new Pagamento(Guid.NewGuid(), caixa);

        public void Efetuar(decimal valor, string descricao, DateTime quando)
        {
            Caixa.SubtrairValor(valor);
            Movimento = Movimento.NovoDeSaida(valor, quando, descricao);
        }

        public Guid Id { get; }
        public Caixa Caixa { get; }
        public Movimento Movimento { get; private set; }
    }
}
