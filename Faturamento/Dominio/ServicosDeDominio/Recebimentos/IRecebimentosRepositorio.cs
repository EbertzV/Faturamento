using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Movimentos;
using Faturamento.Dominio.Operacoes;

namespace Faturamento.Dominio.ServicosDeDominio.Recebimentos
{
    public interface IRecebimentosRepositorio
    {
        void GravarRecebimento(Recebimento recebimento);
    }
}
