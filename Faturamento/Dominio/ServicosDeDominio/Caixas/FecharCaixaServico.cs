using Faturamento.Definicoes;
using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public sealed class FecharCaixaComando : IRequest<Resultado<bool>>
    {
        public FecharCaixaComando(Guid idCaixa)
        {
            IdCaixa = idCaixa;
        }

        public Guid IdCaixa { get; }
    }

    public sealed class FecharCaixaServico : IRequestHandler<FecharCaixaComando, Resultado<bool>>
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IMovimentosRepositorio _movimentosRepositorio;

        public FecharCaixaServico(ICaixaRepositorio caixaRepositorio, IMovimentosRepositorio movimentosRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _movimentosRepositorio = movimentosRepositorio;
        }

        public async Task<Resultado<bool>> Handle(FecharCaixaComando request, CancellationToken cancellationToken)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(request.IdCaixa);
            var movimentos = await _movimentosRepositorio.RecuperarParaCaixaAsync(request.IdCaixa);

            var fechamento = new Fechamento(caixa, ResultadoMovimentosCaixa.NovoAPartirDeMovimentos(movimentos));

            if (fechamento.Executar() is var resultado && resultado.EhFalha)
                return resultado.Falha;    

            await _caixaRepositorio.AtualizarAsync(caixa);
            
            return true;
        }
    }
}
