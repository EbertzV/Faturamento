using Faturamento.Dominio.Movimentos;
using System;
using System.Collections.Generic;

namespace Faturamento.Dominio.ServicosDeDominio.Movimentos
{
    public interface IMovimentosRepositorio
    {
        void Gravar(Movimento movimento);
        IEnumerable<Movimento> RecuperarParaCaixa(Guid caixaId);
    }
}
