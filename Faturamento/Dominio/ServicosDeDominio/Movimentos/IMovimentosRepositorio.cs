using Faturamento.Dominio.Movimentos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Movimentos
{
    public interface IMovimentosRepositorio
    {
        Task<IEnumerable<Movimento>> RecuperarParaCaixaAsync(Guid caixaId);
    }
}
