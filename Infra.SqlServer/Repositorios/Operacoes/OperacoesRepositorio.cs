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
        private readonly CaixaDBContext _caixaDBContext;

        public OperacoesRepositorio(CaixaDBContext caixaDBContext)
        {
            _caixaDBContext = caixaDBContext;
        }

        public async Task GravarAsync(Pagamento pagamento, Guid operadorId)
        {
            var caixaDB = await _caixaDBContext.Caixas.FirstOrDefaultAsync(c => pagamento.Caixa.Id == c.Id);
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
            _caixaDBContext.Movimentos.Add(movimento);

            await _caixaDBContext.Operacoes.AddAsync(new OperacaoDB
            {
                Id = pagamento.Id,
                Pagamento = movimento,
                OperadorId = operadorId
            });

            await _caixaDBContext.SaveChangesAsync();
        }

        public async Task GravarAsync(Recebimento recebimento, Guid operadorId)
        {
            var caixaDB = await _caixaDBContext.Caixas.FirstOrDefaultAsync(c => recebimento.Caixa.Id == c.Id);
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
            _caixaDBContext.Movimentos.Add(movimento);

            await _caixaDBContext.Operacoes.AddAsync(new OperacaoDB
            {
                Id = recebimento.Id,
                Recebimento = movimento,
                OperadorId = operadorId
            });

            await _caixaDBContext.SaveChangesAsync();
        }

        public async Task GravarAsync(Transferencia transferencia, Guid operadorId)
        {
            var caixaOrigem = await _caixaDBContext.Caixas.FirstOrDefaultAsync(c => transferencia.CaixaOrigem.Id == c.Id);
            caixaOrigem.SaldoAtual = transferencia.CaixaOrigem.SaldoAtual;

            var caixaDestino = await _caixaDBContext.Caixas.FirstOrDefaultAsync(c => transferencia.CaixaDestino.Id == c.Id);
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

            await _caixaDBContext.Movimentos.AddAsync(movimentoSaida);

            await _caixaDBContext.Movimentos.AddAsync(movimentoEntrada);

            await _caixaDBContext.Operacoes.AddAsync(new OperacaoDB
            {
                Id = transferencia.Id,
                Pagamento = movimentoSaida,
                Recebimento = movimentoEntrada,
                OperadorId = operadorId
            });
            
            await _caixaDBContext.SaveChangesAsync();
        }
    }
}
