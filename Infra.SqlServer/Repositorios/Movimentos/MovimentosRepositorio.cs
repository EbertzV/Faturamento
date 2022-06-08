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
        private readonly IConfiguration _configuration;

        public MovimentosRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Movimento>> RecuperarParaCaixaAsync(Guid caixaId)
        {
            var contexto = new CaixaDBContext(_configuration);
            var movimentosDb = contexto.Movimentos.Where(m => m.Caixa.Id == caixaId);
            return movimentosDb.Select(m => new Movimento(m.Id, m.Descricao, (ETipoMovimento)Enum.Parse(typeof(ETipoMovimento), m.Tipo), m.Valor, m.Data));
        }
    }
}
