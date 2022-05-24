using Faturamento.Definicoes;

namespace Faturamento.Dominio.Caixas
{
    public static class FalhasFechamento
    {
        public static Falha SaldoInvalido => Falha.Nova(3, "O saldo do caixa é inválido.");
    }
}
