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
        private readonly CaixaDBContext _caixaDBContext;

        public CaixaRepositorio(CaixaDBContext caixaDBContext)
        {
            _caixaDBContext = caixaDBContext;
        }

        public async Task AtualizarAsync(Caixa caixa)
        {
            var caixaAtual = _caixaDBContext.Caixas.FirstOrDefault(c => c.Id == caixa.Id);
            caixaAtual.SaldoAtual = caixa.SaldoAtual;
            caixaAtual.Status = Enum.GetName(typeof(EStatusCaixa), caixa.Status);
            await _caixaDBContext.SaveChangesAsync();
        }

        public async Task<Caixa> RecuperarCaixaAsync(Guid id)
        {
            var caixa = await _caixaDBContext.Caixas.FirstOrDefaultAsync(c => c.Id == id);
            return new Caixa(caixa.Id, caixa.SaldoAtual, caixa.Nome, (EStatusCaixa)Enum.Parse(typeof(EStatusCaixa), caixa.Status));
        }
    }
}
