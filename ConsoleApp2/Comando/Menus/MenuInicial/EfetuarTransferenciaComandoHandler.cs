using System;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Transferencias;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class EfetuarTransferenciaComandoHandler : IComandoHandler
    {
        private readonly IServiceProvider _container;

        public EfetuarTransferenciaComandoHandler(IServiceProvider container)
        {
            _container = container;
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

            var servico = new EfetuarTransferenciaServico(_container.GetService<ICaixaRepositorio>(), _container.GetService<IOperacoesRepositorio>());
            var comando = new EfetuarTransferenciaComando(Guid.Parse(caixaOrigem), Guid.Parse(caixaDestino), decimal.Parse(valor), descricao);

            servico.Executar(comando).GetAwaiter().GetResult();
        }
    }
}
