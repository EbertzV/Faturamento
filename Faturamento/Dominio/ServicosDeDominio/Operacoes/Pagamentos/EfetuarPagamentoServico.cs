using Faturamento.Definicoes;
using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Pagamentos
{
    public sealed class EfetuarPagamentoServico : IRequestHandler<EfetuarPagamentoComando, Resultado<bool>>
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IOperacoesRepositorio _operacoesRepositorio;

        public EfetuarPagamentoServico(ICaixaRepositorio caixaRepositorio, IOperacoesRepositorio operacoesRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _operacoesRepositorio = operacoesRepositorio;
        }

        public async Task<Resultado<bool>> Handle(EfetuarPagamentoComando request, CancellationToken cancellationToken)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(request.CaixaId);

            var pagamento = Pagamento.Novo(caixa);
            pagamento.Efetuar(request.Valor, request.Descricao, DateTime.Now);

            await _operacoesRepositorio.GravarAsync(pagamento, request.OperadorId);

            return true;
        }
    }
}
