using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;

namespace Faturamento.Dominio.Operacoes
{
    public sealed class Recebimento
    {
        public Recebimento(Caixa caixa)
        {
            Caixa = caixa;
        }

        public void Efetuar(decimal valor, string descricao)
        {
            Caixa.AdicionarValor(valor);
            Movimento = Movimento.NovoDeEntrada(valor, Caixa.Id, descricao);
        }

        public Caixa Caixa { get; }
        public Movimento Movimento { get; private set; }
    }
}
