using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using System;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public sealed class FecharCaixa
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IMovimentosRepositorio _movimentosRepositorio;

        public FecharCaixa(ICaixaRepositorio caixaRepositorio, IMovimentosRepositorio movimentosRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _movimentosRepositorio = movimentosRepositorio;
        }

        public async Task Executar(Guid caixaId)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(caixaId);
            var movimentos = await _movimentosRepositorio.RecuperarParaCaixaAsync(caixaId);

            var fechamento = new Fechamento(caixa, new MovimentosDoCaixa(movimentos));
            if (fechamento.Efetuar())
            {
                caixa.Fechar();
                await _caixaRepositorio.AtualizarAsync(caixa);
            }
        }
    }
}
