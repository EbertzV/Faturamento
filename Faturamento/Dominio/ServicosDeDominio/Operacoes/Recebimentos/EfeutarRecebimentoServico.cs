using Faturamento.Definicoes;
using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faturamento.Dominio.Recebimentos
{
    public sealed class EfeutarRecebimentoServico : IRequestHandler<EfetuarRecebimentoComando, Resultado<bool>>
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IOperacoesRepositorio _operacoesRepositorio;

        public EfeutarRecebimentoServico(ICaixaRepositorio caixaRepositorio, IOperacoesRepositorio operacoesRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _operacoesRepositorio = operacoesRepositorio;
        }

        public async Task<Resultado<bool>> Handle(EfetuarRecebimentoComando request, CancellationToken cancellationToken)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(request.CaixaId);

            var recebimento = new Recebimento(caixa, Guid.NewGuid());
            recebimento.Efetuar(request.Valor, request.Descricao, DateTime.Now);

            await _operacoesRepositorio.GravarAsync(recebimento, request.OperadorId);

            return true;
        }
    }
}
