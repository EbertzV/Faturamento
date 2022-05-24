using System;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using MediatR;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class AbrirCaixaComandoHandler : IComandoHandler
    {
        private readonly IMediator _mediator;

        public AbrirCaixaComandoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Executar()
        {
            Console.WriteLine("Informe o caixa");
            var caixa = Console.ReadLine();

            _mediator.Send(new AbrirCaixaComando(Guid.Parse(caixa))).GetAwaiter().GetResult();
        }
    }
}
