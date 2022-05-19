using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Pagamentos
{
    public sealed class EfetuarPagamentoServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IOperacoesRepositorio _operacoesRepositorio;

        public EfetuarPagamentoServico(ICaixaRepositorio caixaRepositorio, IOperacoesRepositorio operacoesRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _operacoesRepositorio = operacoesRepositorio;
        }

        public async Task Executar(EfetuarPagamentoComando comando)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(comando.CaixaId);

            var pagamento = new Pagamento(caixa);
            pagamento.Efetuar(comando.Valor, comando.Descricao);

            await _operacoesRepositorio.GravarAsync(pagamento);
        }
    }
}
