using Faturamento.Dominio.ServicosDeDominio.Caixas;
using MediatR;
using System;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class FecharCaixaComandoHandler : IComandoHandler
    {
        private readonly IMediator _mediator;

        public FecharCaixaComandoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Executar(Guid operadorId)
        {
            Console.WriteLine("Digite o caixa");
            var caixa = Console.ReadLine();

            var comando = new FecharCaixaComando(Guid.Parse(caixa));

            _mediator.Send(comando).GetAwaiter().GetResult();
        }
    }
}
