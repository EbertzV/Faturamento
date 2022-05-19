using System;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class AbrirCaixaComandoHandler : IComandoHandler
    {
        private readonly IServiceProvider _container;

        public AbrirCaixaComandoHandler(IServiceProvider container)
        {
            _container = container;
        }

        public void Executar()
        {
            Console.WriteLine("Informe o caixa");
            var caixa = Console.ReadLine();

            var servico = new AbrirCaixa(_container.GetService<ICaixaRepositorio>());

            servico.Executar(Guid.Parse(caixa)).GetAwaiter().GetResult();
        }
    }
}
