using Cliente.Comando.Menus.MenuInicial;
using Cliente.Comando.Menus.Vazio;
using MediatR;

namespace Cliente
{
    public sealed class ComandoInicialFactory : IComandoFactory
    {
        private readonly IMediator _mediator;

        public ComandoInicialFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IComandoHandler Gerar(string comando)
        {
            switch (comando)
            {
                case "receber":
                    return new EfetuarRecebimentoComandoHandler(_mediator);
                case "abrir caixa":
                    return new AbrirCaixaComandoHandler(_mediator);
                case "fechar caixa":
                    return new FecharCaixaComandoHandler(_mediator);
                case "pagar":
                    return new EfetuarPagamentoComandoHandler(_mediator);
                case "transferir":
                    return new EfetuarTransferenciaComandoHandler(_mediator);
                default:
                    return new ComandoVazioHandler();
            }
        }
    }
}
