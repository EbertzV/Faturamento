using Faturamento.Dominio.Definicoes;
using System;

namespace Faturamento.Dominio.Movimentos
{
    public class MovimentoEntrada : Movimento
    {
        public MovimentoEntrada(Guid id, string descricao, decimal valor, DateTime data) : base(id, descricao, ETipoMovimento.Entrada, valor, data)
        {

        }
    }
}
