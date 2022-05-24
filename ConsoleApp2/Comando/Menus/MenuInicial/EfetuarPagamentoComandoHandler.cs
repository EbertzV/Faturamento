using System;
using Faturamento.Dominio.ServicosDeDominio.Pagamentos;
using MediatR;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class EfetuarPagamentoComandoHandler : IComandoHandler
    {
        private readonly IMediator _mediator;

        public EfetuarPagamentoComandoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Executar(Guid operadorId)
        {
            Console.WriteLine("Informe o caixa");
            var caixa = Console.ReadLine();

            Console.WriteLine("Informe o valor");
            var valor = Console.ReadLine();

            Console.WriteLine("Informe a descrição");
            var descricao = Console.ReadLine();

            var comando = new EfetuarPagamentoComando(Guid.Parse(caixa), decimal.Parse(valor), descricao, operadorId);

            _mediator.Send(comando).GetAwaiter().GetResult();
        }
    }
}
