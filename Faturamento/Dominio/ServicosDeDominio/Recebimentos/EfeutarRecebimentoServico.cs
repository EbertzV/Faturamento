using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Recebimentos;

namespace Faturamento.Dominio.Recebimentos
{
    public sealed class EfeutarRecebimentoServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IRecebimentosRepositorio _recebimentosRepositorio;

        public EfeutarRecebimentoServico(ICaixaRepositorio caixaRepositorio, IRecebimentosRepositorio recebimentosRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _recebimentosRepositorio = recebimentosRepositorio;
        }

        public void Executar(EfetuarRecebimentoComando comando)
        {
            var caixa = _caixaRepositorio.RecuperarCaixa(comando.CaixaId);

            var recebimento = new Recebimento(caixa);
            recebimento.Efetuar(comando.Valor, comando.Descricao);

            _recebimentosRepositorio.GravarRecebimento(recebimento);
        }
    }
}
