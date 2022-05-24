using Faturamento.Dominio.Operacoes;
using System;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Operacoes
{
    public interface IOperacoesRepositorio
    {
        Task GravarAsync(Pagamento pagamento, Guid operadorId);
        Task GravarAsync(Recebimento recebimento, Guid operadorId);
        Task GravarAsync(Transferencia transferencia, Guid operadorId);
    }
}
