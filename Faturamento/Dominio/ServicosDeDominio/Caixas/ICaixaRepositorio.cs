using Faturamento.Dominio.Caixas;
using System;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public interface ICaixaRepositorio
    {
        Task<Caixa> RecuperarCaixaAsync(Guid id);
        Task AtualizarAsync(Caixa caixa);
    }
}
