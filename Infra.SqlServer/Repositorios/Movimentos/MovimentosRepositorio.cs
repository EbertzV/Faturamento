using Faturamento.Dominio.Definicoes;
using Faturamento.Dominio.Movimentos;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using Infra.SqlServer.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.SqlServer.Repositorios.Movimentos
{
    public sealed class MovimentosRepositorio : IMovimentosRepositorio
    {
        public async Task<IEnumerable<Movimento>> RecuperarParaCaixaAsync(Guid caixaId)
        {
            using var contexto = new CaixaDBContext();
            var movimentosDb = contexto.Movimentos.Where(m => m.Caixa.Id == caixaId);
            return movimentosDb.Select(m => new Movimento(m.Id, m.Descricao, (ETipoMovimento)Enum.Parse(typeof(ETipoMovimento), m.Tipo), m.Valor));
        }
    }
}
