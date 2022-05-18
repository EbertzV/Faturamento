namespace Faturamento.Dominio.Caixas
{
    public sealed class Fechamento
    {
       
        public Fechamento(Caixa caixa, MovimentosDoCaixa movimentos)
        {
            Caixa = caixa;
            Movimentos = movimentos;
        }

        private bool SaldoEhValido()
            => Movimentos.TotalMovimentos() == Caixa.SaldoAtual;

        public bool Efetuar()
        {
            if(SaldoEhValido())
            {
                Caixa.Fechar();
                return true;
            } else
            {
                return false;
            }
        }

        public Caixa Caixa { get; }
        public MovimentosDoCaixa Movimentos { get; }
    }
}
