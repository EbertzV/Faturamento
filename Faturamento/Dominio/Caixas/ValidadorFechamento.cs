using Faturamento.Definicoes;

namespace Faturamento.Dominio.Caixas
{
    public sealed class Fechamento
    {
        private readonly ValidadorSaldo _validadorSaldo;
        private readonly Caixa _caixa;
        public Fechamento(Caixa caixa, ResultadoMovimentosCaixa resultadoMovimentos)
        {
            _caixa = caixa;
            _validadorSaldo = new ValidadorSaldo(caixa, resultadoMovimentos);
        }

        public Resultado<bool> Executar()
        {
            if (_validadorSaldo.SaldoConfere)
            {
                _caixa.Fechar();
                return true;
            }
            else return FalhasFechamento.SaldoInvalido;
        }
    }
}
