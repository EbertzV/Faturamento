using Faturamento.Dominio.Recebimentos;
using System;
using MediatR;
using Faturamento.Definicoes;
using System.Threading.Tasks;
using System.Threading;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class EfetuarRecebimentoComandoHandler : IComandoHandler
    {
        private readonly IMediator _mediator;

        public EfetuarRecebimentoComandoHandler(IMediator mediator)
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
            
            var comando = new EfetuarRecebimentoComando(Guid.Parse(caixa), decimal.Parse(valor), descricao, operadorId);
            
            var resultado = _mediator.Send(comando).GetAwaiter().GetResult();
        }
    }
}
