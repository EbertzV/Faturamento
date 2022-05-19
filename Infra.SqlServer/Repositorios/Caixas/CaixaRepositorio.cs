using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Definicoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Infra.SqlServer.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.SqlServer.Caixas
{
    public sealed class CaixaRepositorio : ICaixaRepositorio
    {
        public async Task AtualizarAsync(Caixa caixa)
        {
            using var context = new CaixaDBContext();
            var caixaAtual = context.Caixas.FirstOrDefault(c => c.Id == caixa.Id);
            caixaAtual.SaldoAtual = caixa.SaldoAtual;
            caixaAtual.Status = Enum.GetName(typeof(EStatusCaixa), caixa.Status);
            await context.SaveChangesAsync();
        }

        public async Task<Caixa> RecuperarCaixaAsync(Guid id)
        {
            using var context = new CaixaDBContext();
            var caixa = await context.Caixas.FirstOrDefaultAsync(c => c.Id == id);
            return new Caixa(caixa.Id, caixa.SaldoAtual, caixa.Nome, (EStatusCaixa)Enum.Parse(typeof(EStatusCaixa), caixa.Status));
        }
    }
}
