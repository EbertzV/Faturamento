using System;
using Faturamento.Dominio.ServicosDeDominio.Transferencias;
using MediatR;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class EfetuarTransferenciaComandoHandler : IComandoHandler
    {
        private readonly IMediator _mediator;

        public EfetuarTransferenciaComandoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Executar()
        {
            Console.WriteLine("Informe o caixa de origem");
            var caixaOrigem = Console.ReadLine();

            Console.WriteLine("Informe o caixa de destino");
            var caixaDestino = Console.ReadLine();

            Console.WriteLine("Informe o valor");
            var valor = Console.ReadLine();

            Console.WriteLine("Informe o caixa");
            var descricao = Console.ReadLine();

            var comando = new EfetuarTransferenciaComando(Guid.Parse(caixaOrigem), Guid.Parse(caixaDestino), decimal.Parse(valor), descricao);

            _mediator.Send(comando).GetAwaiter().GetResult();
        }
    }
}
