using Faturamento.Dominio.Recebimentos;
using System;
using MediatR;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class EfetuarRecebimentoComandoHandler : IComandoHandler
    {
        private readonly IMediator _mediator;

        public EfetuarRecebimentoComandoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Executar()
        {
            Console.WriteLine("Informe o caixa");
            var caixa = Console.ReadLine();

            Console.WriteLine("Informe o valor");
            var valor = Console.ReadLine();

            Console.WriteLine("Informe a descrição");
            var descricao = Console.ReadLine();
            
            var comando = new EfetuarRecebimentoComando(Guid.Parse(caixa), decimal.Parse(valor), descricao);
            
            var resultado = _mediator.Send(comando).GetAwaiter().GetResult();
        }
    }
}
