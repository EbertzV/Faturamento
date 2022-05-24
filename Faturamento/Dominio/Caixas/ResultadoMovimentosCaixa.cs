using Faturamento.Dominio.Movimentos;
using System.Collections.Generic;

namespace Faturamento.Dominio.Caixas
{
    public sealed class ResultadoMovimentosCaixa
    {
        private ResultadoMovimentosCaixa(MovimentosDeEntradaDoCaixa entrada, MovimentosDeSaidaDoCaixa saida)
        {
            Entrada = entrada;
            Saida = saida;
        }

        public static ResultadoMovimentosCaixa NovoAPartirDeMovimentos(IEnumerable<Movimento> movimentos)
            => new ResultadoMovimentosCaixa(
                    MovimentosDeEntradaDoCaixa.Recuperar(movimentos),
                    MovimentosDeSaidaDoCaixa.Recuperar(movimentos));

        private MovimentosDeEntradaDoCaixa Entrada { get; }
        private MovimentosDeSaidaDoCaixa Saida { get; }

        public decimal Valor => Entrada.Total - Saida.Total;
    }
}

