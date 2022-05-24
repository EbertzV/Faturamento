using Faturamento.Definicoes;
using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Transferencias
{
    public sealed class EfetuarTransferenciaServico : IRequestHandler<EfetuarTransferenciaComando, Resultado<bool>>
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IOperacoesRepositorio _operacoesRepositorio;

        public EfetuarTransferenciaServico(ICaixaRepositorio caixaRepositorio, IOperacoesRepositorio operacoesRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _operacoesRepositorio = operacoesRepositorio;
        }

        public async Task<Resultado<bool>> Handle(EfetuarTransferenciaComando request, CancellationToken cancellationToken)
        {
            var caixaOrigem = await _caixaRepositorio.RecuperarCaixaAsync(request.CaixaOrigemId);
            var caixaDestino = await _caixaRepositorio.RecuperarCaixaAsync(request.CaixaDestinoId);

            var transferencia = Transferencia
                .Nova(caixaOrigem, caixaDestino)
                .Efetuar(request.Valor, DateTime.Now, request.Descricao);

            await _operacoesRepositorio.GravarAsync(transferencia, request.OperadorId);

            return true;
        }
    }
}
