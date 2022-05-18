using Faturamento.Dominio.Operacoes;

namespace Faturamento.Dominio.ServicosDeDominio.Transferencias
{
    public interface  ITransferenciasRepositorio
    {
        void GravarTransferencia(Transferencia transferencia);
    }
}
