using Faturamento.Dominio.Definicoes;
using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using Infra.SqlServer.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Infra.SqlServer.Repositorios.Operacoes
{
    public sealed class OperacoesRepositorio : IOperacoesRepositorio
    {
        private readonly IConfiguration _configuration;

        public OperacoesRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task GravarAsync(Pagamento pagamento, Guid operadorId)
        {
            using var context = new CaixaDBContext(_configuration);
            var caixaDB = await context.Caixas.FirstOrDefaultAsync(c => pagamento.Caixa.Id == c.Id);
            caixaDB.SaldoAtual = pagamento.Caixa.SaldoAtual;

            var movimento = new MovimentoDB
            {
                Id = pagamento.Movimento.Id,
                Descricao = pagamento.Movimento.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), pagamento.Movimento.Tipo),
                Valor = pagamento.Movimento.Valor,
                Data = pagamento.Movimento.Data,
                Caixa = caixaDB
            };
            context.Movimentos.Add(movimento);

            await context.Operacoes.AddAsync(new OperacaoDB
            {
                Id = pagamento.Id,
                Pagamento = movimento,
                OperadorId = operadorId
            });

            await context.SaveChangesAsync();
        }

        public async Task GravarAsync(Recebimento recebimento, Guid operadorId)
        {
            using var context = new CaixaDBContext(_configuration);
            var caixaDB = await context.Caixas.FirstOrDefaultAsync(c => recebimento.Caixa.Id == c.Id);
            caixaDB.SaldoAtual = recebimento.Caixa.SaldoAtual;

            var movimento = new MovimentoDB
            {
                Id = recebimento.Movimento.Id,
                Descricao = recebimento.Movimento.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), recebimento.Movimento.Tipo),
                Valor = recebimento.Movimento.Valor,
                Data = recebimento.Movimento.Data,
                Caixa = caixaDB
            };
            context.Movimentos.Add(movimento);

            await context.Operacoes.AddAsync(new OperacaoDB
            {
                Id = recebimento.Id,
                Recebimento = movimento,
                OperadorId = operadorId
            });

            await context.SaveChangesAsync();
        }

        public async Task GravarAsync(Transferencia transferencia, Guid operadorId)
        {
            using var context = new CaixaDBContext(_configuration);
            var caixaOrigem = await context.Caixas.FirstOrDefaultAsync(c => transferencia.CaixaOrigem.Id == c.Id);
            caixaOrigem.SaldoAtual = transferencia.CaixaOrigem.SaldoAtual;

            var caixaDestino = await context.Caixas.FirstOrDefaultAsync(c => transferencia.CaixaDestino.Id == c.Id);
            caixaDestino.SaldoAtual = transferencia.CaixaDestino.SaldoAtual;

            var movimentoSaida = new MovimentoDB
            {
                Id = transferencia.MovimentoSaida.Id,
                Descricao = transferencia.MovimentoSaida.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), transferencia.MovimentoSaida.Tipo),
                Valor = transferencia.MovimentoSaida.Valor,
                Data = transferencia.MovimentoSaida.Data,
                Caixa = caixaOrigem
            };

            var movimentoEntrada = new MovimentoDB
            {
                Id = transferencia.MovimentoEntrada.Id,
                Descricao = transferencia.MovimentoEntrada.Descricao,
                Tipo = Enum.GetName(typeof(ETipoMovimento), transferencia.MovimentoEntrada.Tipo),
                Valor = transferencia.MovimentoEntrada.Valor,
                Data = transferencia.MovimentoEntrada.Data,
                Caixa = caixaDestino
            };

            await context.Movimentos.AddAsync(movimentoSaida);

            await context.Movimentos.AddAsync(movimentoEntrada);

            await context.Operacoes.AddAsync(new OperacaoDB
            {
                Id = transferencia.Id,
                Pagamento = movimentoSaida,
                Recebimento = movimentoEntrada,
                OperadorId = operadorId
            });
            
            await context.SaveChangesAsync();
        }
    }
}
