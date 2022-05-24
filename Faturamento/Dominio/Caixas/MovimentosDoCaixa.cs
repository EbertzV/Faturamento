using Faturamento.Dominio.Movimentos;
using System.Collections.Generic;
using System.Linq;

namespace Faturamento.Dominio.Caixas
{

    public abstract class MovimentosDoCaixa
    {
        protected MovimentosDoCaixa(IEnumerable<Movimento> movimentos)
        {
            Movimentos = movimentos;
        }

        protected IEnumerable<Movimento> Movimentos { get; }

        public virtual decimal Total => Movimentos.Sum(m => m.Valor);
    }

    public sealed class MovimentosDeEntradaDoCaixa : MovimentosDoCaixa
    {
        private MovimentosDeEntradaDoCaixa(IEnumerable<Movimento> movimentos) : base(movimentos)
        {
            
        }

        public static MovimentosDeEntradaDoCaixa Recuperar(IEnumerable<Movimento> movimentos)
            => new MovimentosDeEntradaDoCaixa(movimentos.Where(m => m.SouDeEntrada()));
    }

    public sealed class MovimentosDeSaidaDoCaixa : MovimentosDoCaixa
    {
        private MovimentosDeSaidaDoCaixa(IEnumerable<Movimento> movimentos) : base(movimentos)
        {
        }

        public static MovimentosDeSaidaDoCaixa Recuperar(IEnumerable<Movimento> movimentos)
            => new MovimentosDeSaidaDoCaixa(movimentos.Where(m => m.SouDeSaida()));
    }
}

