using Cliente;
using Cliente.Comando;
using Cliente.Template;
using Infra.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

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

            var comando = "";
            while (comando != "sair")
            {
                var menu = new MenuFactory(_serviceProvider).Gerar("menu_inicial");
                Console.Write(_fillTemplate.Fill("menu_inicial"));

                comando = Console.ReadLine();
                var comandoHandler = menu.Gerar(comando);
                comandoHandler.Executar();
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
            ServiceProviderConfiguration.AdicionarServicos(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
