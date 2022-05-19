using Faturamento.Dominio.Definicoes;
using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using Infra.SqlServer.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infra.SqlServer.Repositorios.Operacoes
{
    public sealed class OperacoesRepositorio : IOperacoesRepositorio
    {
        public async Task GravarAsync(Pagamento pagamento)
        {
            using var context = new CaixaDBContext();
            var caixaDB = await context.Caixas.FirstOrDefaultAsync(c => pagamento.Caixa.Id == c.Id);
            caixaDB.SaldoAtual = pagamento.Caixa.SaldoAtual;
            context.Movimentos.Add(new MovimentoDB
            {
                Id = pagamento.Movimento.Id,
                Descricao = pagamento.Movimento.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), pagamento.Movimento.Tipo),
                Valor = pagamento.Movimento.Valor,
                Caixa = caixaDB
            });
            await context.SaveChangesAsync();
        }

        public async Task GravarAsync(Recebimento recebimento)
        {
            using var context = new CaixaDBContext();
            var caixaDB = await context.Caixas.FirstOrDefaultAsync(c => recebimento.Caixa.Id == c.Id);
            caixaDB.SaldoAtual = recebimento.Caixa.SaldoAtual;
            context.Movimentos.Add(new MovimentoDB
            {
                Id = recebimento.Movimento.Id,
                Descricao = recebimento.Movimento.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), recebimento.Movimento.Tipo),
                Valor = recebimento.Movimento.Valor,
                Caixa = caixaDB
            });
            await context.SaveChangesAsync();
        }

        public async Task GravarAsync(Transferencia transferencia)
        {
            using var context = new CaixaDBContext();
            var caixaOrigem = await context.Caixas.FirstOrDefaultAsync(c => transferencia.CaixaOrigem.Id == c.Id);
            caixaOrigem.SaldoAtual = transferencia.CaixaOrigem.SaldoAtual;

            var caixaDestino = await context.Caixas.FirstOrDefaultAsync(c => transferencia.CaixaDestino.Id == c.Id);
            caixaDestino.SaldoAtual = transferencia.CaixaDestino.SaldoAtual;

            await context.Movimentos.AddAsync(new MovimentoDB
            {
                Id = transferencia.MovimentoSaida.Id,
                Descricao = transferencia.MovimentoSaida.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), transferencia.MovimentoSaida.Tipo),
                Valor = transferencia.MovimentoSaida.Valor,
                Caixa = caixaOrigem
            });

            await context.Movimentos.AddAsync(new MovimentoDB
            {
                Id = transferencia.MovimentoEntrada.Id,
                Descricao = transferencia.MovimentoEntrada.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), transferencia.MovimentoEntrada.Tipo),
                Valor = transferencia.MovimentoEntrada.Valor,
                Caixa = caixaDestino
            });

            
            await context.SaveChangesAsync();
        }
    }
}
