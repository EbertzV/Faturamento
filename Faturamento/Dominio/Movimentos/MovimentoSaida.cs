using Faturamento.Dominio.Definicoes;
using System;

namespace Faturamento.Dominio.Movimentos
{
    public class MovimentoSaida : Movimento
    {
        public MovimentoSaida(Guid id, string descricao, decimal valor, DateTime data) : base(id, descricao, ETipoMovimento.Saida, valor, data)
        {

        }
    }
}
