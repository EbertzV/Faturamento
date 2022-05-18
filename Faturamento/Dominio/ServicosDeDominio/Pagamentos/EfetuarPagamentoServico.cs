using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;

namespace Faturamento.Dominio.ServicosDeDominio.Pagamentos
{
    public sealed class EfetuarPagamentoServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IPagamentosRepositorio _pagamentosRepositorio;

        public EfetuarPagamentoServico(ICaixaRepositorio caixaRepositorio, IPagamentosRepositorio pagamentosRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _pagamentosRepositorio = pagamentosRepositorio;
        }

        public void Executar(EfetuarPagamentoComando comando)
        {
            var caixa = _caixaRepositorio.RecuperarCaixa(comando.CaixaId);

            var pagamento = new Pagamento(caixa);
            pagamento.Efetuar(comando.Valor, comando.Descricao);

            _pagamentosRepositorio.Gravar(pagamento);
        }
    }
}
