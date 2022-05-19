using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;

namespace Faturamento.Dominio.Operacoes
{
    public sealed class Pagamento
    {
        public Pagamento(Caixa caixa)
        {
            Caixa = caixa;
        }

        public void Efetuar(decimal valor, string descricao)
        {
            Caixa.SubtrairValor(valor);
            Movimento = Movimento.NovoDeSaida(valor, descricao);
        }

        public Caixa Caixa { get; }
        public Movimento Movimento { get; private set; }
    }
}
