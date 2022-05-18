using Faturamento.Dominio.Caixas;
using System;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public interface ICaixaRepositorio
    {
        Caixa RecuperarCaixa(Guid id);
        void AtualizarSaldo(Caixa caixa);
        void Atualizar(Caixa caixa);
    }
}
