using Cliente.Comando;
using Cliente.Template;
using Faturamento.Definicoes;
using Faturamento.Dominio.Recebimentos;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Pagamentos;
using Faturamento.Dominio.ServicosDeDominio.Transferencias;
using Infra.SqlServer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp2
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static readonly string _config = "./template/config.txt";
        private static readonly FillTemplate _fillTemplate = new FillTemplate(_config);

        static void Main(string[] args)
        {
            Setup();

            Console.Write(_fillTemplate.Fill("cabecalho"));

            Console.WriteLine("Digite o id do operador:\n");
            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                id = Guid.NewGuid();

            var comando = "";
            while (comando != "sair")
            {
                var menu = new MenuFactory(_serviceProvider.GetService<IMediator>()).Gerar("menu_inicial");
                Console.Write(_fillTemplate.Fill("menu_inicial"));

                comando = Console.ReadLine();
                var comandoHandler = menu.Gerar(comando);
                comandoHandler.Executar(id);
            }
            
            Console.Write(_fillTemplate.Fill("final_sucesso"));
        }

        public static void Setup()
        {
            ConfigureServices();
        }

        public static void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddMediatR(typeof(Program))
                .AddScoped<IRequestHandler<EfetuarRecebimentoComando, Resultado<bool>>, EfeutarRecebimentoServico>()
                .AddScoped<IRequestHandler<EfetuarTransferenciaComando, Resultado<bool>>, EfetuarTransferenciaServico>()
                .AddScoped<IRequestHandler<EfetuarPagamentoComando, Resultado<bool>>, EfetuarPagamentoServico>()
                .AddScoped<IRequestHandler<FecharCaixaComando, Resultado<bool>>, FecharCaixa>()
                .AddScoped<IRequestHandler<AbrirCaixaComando, Resultado<bool>>, AbrirCaixa>();
            ServiceProviderConfiguration.AdicionarServicos(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
