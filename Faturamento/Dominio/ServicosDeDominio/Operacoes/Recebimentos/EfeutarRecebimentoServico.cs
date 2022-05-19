using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using System.Threading.Tasks;

namespace Faturamento.Dominio.Recebimentos
{
    public sealed class EfeutarRecebimentoServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IOperacoesRepositorio _operacoesRepositorio;

        public EfeutarRecebimentoServico(ICaixaRepositorio caixaRepositorio, IOperacoesRepositorio operacoesRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _operacoesRepositorio = operacoesRepositorio;
        }

        public async Task Executar(EfetuarRecebimentoComando comando)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(comando.CaixaId);

            var recebimento = new Recebimento(caixa);
            recebimento.Efetuar(comando.Valor, comando.Descricao);

            await _operacoesRepositorio.GravarAsync(recebimento);
        }
    }
}
