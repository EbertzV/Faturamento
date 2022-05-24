using Faturamento.Definicoes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public sealed class AbrirCaixaComando : IRequest<Resultado<bool>>
    {
        public AbrirCaixaComando(Guid idCaixa)
        {
            IdCaixa = idCaixa;
        }

        public Guid IdCaixa { get; }
    }

    public sealed class AbrirCaixa : IRequestHandler<AbrirCaixaComando, Resultado<bool>>
    {
        private readonly ICaixaRepositorio _caixaRepositorio;

        public AbrirCaixa(ICaixaRepositorio caixaRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
        }

        public async Task<Resultado<bool>> Handle(AbrirCaixaComando request, CancellationToken cancellationToken)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(request.IdCaixa);

            caixa.Abrir();

            await _caixaRepositorio.AtualizarAsync(caixa);

            return true;
        }
    }
}
