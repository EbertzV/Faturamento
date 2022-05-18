
using Faturamento.Dominio.Operacoes;

namespace Faturamento.Dominio.ServicosDeDominio.Pagamentos
{
    public interface IPagamentosRepositorio
    {
        void Gravar(Pagamento pagamento);
    }
}
