using Faturamento.Dominio.Definicoes;
using Faturamento.Dominio.Movimentos;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using Infra.SqlServer.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.SqlServer.Repositorios.Movimentos
{
    public sealed class MovimentosRepositorio : IMovimentosRepositorio
    {
        private readonly CaixaDBContext _caixaDBContext;

        public MovimentosRepositorio(CaixaDBContext caixaDBContext)
        {
            _caixaDBContext = caixaDBContext;
        }
        public async Task<IEnumerable<Movimento>> RecuperarParaCaixaAsync(Guid caixaId)
        {
            var movimentosDb = _caixaDBContext.Movimentos.Where(m => m.Caixa.Id == caixaId).ToList();
            return movimentosDb.Select(m => new Movimento(m.Id, m.Descricao, (ETipoMovimento)Enum.Parse(typeof(ETipoMovimento), (string)m.Tipo), m.Valor, m.Data));
        }
    }
}
