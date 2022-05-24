using Faturamento.Definicoes;

namespace Faturamento.Dominio.Caixas
{
    public static class FalhasCaixa
    {
        public static Falha CaixaFechado => Falha.Nova(1, "O caixa está fechado.");
        public static Falha ValorNaoEhMaiorQueZero => Falha.Nova(2, "O valor informado deveria ser maior que zero.");
    }
}
