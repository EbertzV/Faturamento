using Autofac;
using Cliente.Comando;
using Cliente.Template;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace ConsoleApp2
{
    class Program
    {
        private static IContainer _serviceProvider;
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
                var menu = new MenuFactory(_serviceProvider.Resolve<IMediator>()).Gerar("menu_inicial");
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
            var builder = new ContainerBuilder();

            var faturamento = Assembly.Load("Faturamento");
            var infra = Assembly.Load("Infra.SqlServer");

            builder.RegisterMediatR(typeof(Program).Assembly, faturamento, infra);

            builder
                .RegisterAssemblyTypes(faturamento)
                .Where(t => t.Name.EndsWith("Repositorio"))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(faturamento)
                .Where(t => t.Name.EndsWith("Servico"))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(infra)
                .Where(t => t.Name.EndsWith("Repositorio"))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(infra)
                .Where(t => t.Name.EndsWith("Servico"))
                .AsImplementedInterfaces();

            _serviceProvider = builder.Build();
        }
    }
}
