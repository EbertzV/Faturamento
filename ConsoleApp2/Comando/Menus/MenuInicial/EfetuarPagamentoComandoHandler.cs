using System;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Pagamentos;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.Comando.Menus.MenuInicial
{
    public sealed class EfetuarPagamentoComandoHandler : IComandoHandler
    {
        private readonly IServiceProvider _container;

        public EfetuarPagamentoComandoHandler(IServiceProvider container)
        {
            _container = container;
        }

        public void Executar()
        {
            Console.WriteLine("Informe o caixa");
            var caixa = Console.ReadLine();

            Console.WriteLine("Informe o valor");
            var valor = Console.ReadLine();

            Console.WriteLine("Informe a descrição");
            var descricao = Console.ReadLine();

            var servico = new EfetuarPagamentoServico(_container.GetService<ICaixaRepositorio>(), _container.GetService<IOperacoesRepositorio>());
            var comando = new EfetuarPagamentoComando(Guid.Parse(caixa), decimal.Parse(valor), descricao);

            servico.Executar(comando).GetAwaiter().GetResult();
        }
    }
}
