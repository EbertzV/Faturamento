namespace Faturamento.Dominio.Caixas
{
    public sealed class ValidadorSaldo
    {
        public ValidadorSaldo(Caixa caixa, ResultadoMovimentosCaixa movimentos)
        {
            Caixa = caixa;
            ResultadoMovimentos = movimentos;
        }

        public bool SaldoConfere 
            => Caixa.SaldoAtual == ResultadoMovimentos.Valor;

        private Caixa Caixa { get; }
        private ResultadoMovimentosCaixa ResultadoMovimentos { get; }
    }
}
