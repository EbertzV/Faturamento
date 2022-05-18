using Faturamento.Dominio.Movimentos;
using System.Collections.Generic;
using System.Linq;

namespace Faturamento.Dominio.Caixas
{
    public sealed class MovimentosDoCaixa
    {
        public MovimentosDoCaixa(IEnumerable<Movimento> movimentos)
        {
            Movimentos = movimentos;
        }

        public IEnumerable<Movimento> Movimentos { get; }

        private decimal TotalMovimentosEntrada()
            => Movimentos
                .Where(m => m.SouDeEntrada())
                .Sum(e => e.Valor);

        private decimal TotalMovimentosSaida()
            => Movimentos
                .Where(m => m.SouDeSaida())
                .Sum(s => s.Valor);

        public decimal TotalMovimentos()
            => TotalMovimentosEntrada() - TotalMovimentosSaida();
    }
}
