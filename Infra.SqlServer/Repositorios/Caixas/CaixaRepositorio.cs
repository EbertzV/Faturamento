using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Definicoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Infra.SqlServer.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.SqlServer.Caixas
{
    public sealed class CaixaRepositorio : ICaixaRepositorio
    {
        private readonly IConfiguration _configuration;

        public CaixaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AtualizarAsync(Caixa caixa)
        {
            using var context = new CaixaDBContext(_configuration);
            var caixaAtual = context.Caixas.FirstOrDefault(c => c.Id == caixa.Id);
            caixaAtual.SaldoAtual = caixa.SaldoAtual;
            caixaAtual.Status = Enum.GetName(typeof(EStatusCaixa), caixa.Status);
            await context.SaveChangesAsync();
        }

        public async Task<Caixa> RecuperarCaixaAsync(Guid id)
        {
            var context = new CaixaDBContext(_configuration);
            var caixa = await context.Caixas.FirstOrDefaultAsync(c => c.Id == id);
            return new Caixa(caixa.Id, caixa.SaldoAtual, caixa.Nome, (EStatusCaixa)Enum.Parse(typeof(EStatusCaixa), caixa.Status));
        }
    }
}
