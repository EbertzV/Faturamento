using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using System;

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

        public void Executar(Guid caixaId)
        {
            var caixa = _caixaRepositorio.RecuperarCaixa(caixaId);
            var movimentos = _movimentosRepositorio.RecuperarParaCaixa(caixaId);

            var fechamento = new Fechamento(caixa, new MovimentosDoCaixa(movimentos));
            if (fechamento.Efetuar())
            {
                caixa.Fechar();
                _caixaRepositorio.Atualizar(caixa);
            }
        }
    }
}
