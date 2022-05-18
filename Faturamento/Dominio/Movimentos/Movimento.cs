using Faturamento.Dominio.Definicoes;
using System;

namespace Faturamento.Dominio.Movimentos
{
    public sealed class Movimento
    {
        public Movimento(Guid id, string descricao, ETipoMovimento tipo, decimal valor, Guid caixaId)
        {
            Id = id;
            Descricao = descricao;
            Tipo = tipo;
            Valor = valor;
            CaixaId = caixaId;
        }

        public static Movimento NovoDeEntrada(decimal valor, Guid caixa, string descricao = "")
            => new Movimento(Guid.NewGuid(), descricao, ETipoMovimento.Entrada, valor, caixa);

        public static Movimento NovoDeSaida(decimal valor, Guid caixa, string descricao = "")
            => new Movimento(Guid.NewGuid(), descricao, ETipoMovimento.Saida, valor, caixa);

        public bool SouDeEntrada()
            => Tipo == ETipoMovimento.Entrada;

        public bool SouDeSaida()
            => Tipo == ETipoMovimento.Saida;

        public Guid Id { get; }
        public string Descricao { get; }
        public ETipoMovimento Tipo { get; }
        public decimal Valor { get; }
        public Guid CaixaId { get; }
    }
}
