using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using Infra.SqlServer.Caixas;
using Infra.SqlServer.Repositorios.Movimentos;
using Infra.SqlServer.Repositorios.Operacoes;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.SqlServer
{
    public sealed class ServiceProviderConfiguration 
    {
        public static void AdicionarServicos(IServiceCollection services)
        {
            services.AddScoped<ICaixaRepositorio, CaixaRepositorio>();
            services.AddScoped<IMovimentosRepositorio, MovimentosRepositorio>();
            services.AddScoped<IOperacoesRepositorio, OperacoesRepositorio>();
        }
    }
}
