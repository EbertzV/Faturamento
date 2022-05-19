using Faturamento.Dominio.Operacoes;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Operacoes
{
    public interface IOperacoesRepositorio
    {
        Task GravarAsync(Pagamento pagamento);
        Task GravarAsync(Recebimento recebimento);
        Task GravarAsync(Transferencia transferencia);
    }
}
