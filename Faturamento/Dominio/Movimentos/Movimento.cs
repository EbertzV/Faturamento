using Faturamento.Dominio.Definicoes;
using System;

namespace Faturamento.Dominio.Movimentos
{
    public sealed class Movimento
    {
        public Movimento(Guid id, string descricao, ETipoMovimento tipo, decimal valor)
        {
            Id = id;
            Descricao = descricao;
            Tipo = tipo;
            Valor = valor;
        }

        public static Movimento NovoDeEntrada(decimal valor, string descricao = "")
            => new Movimento(Guid.NewGuid(), descricao, ETipoMovimento.Entrada, valor);

        public static Movimento NovoDeSaida(decimal valor, string descricao = "")
            => new Movimento(Guid.NewGuid(), descricao, ETipoMovimento.Saida, valor);

        public bool SouDeEntrada()
            => Tipo == ETipoMovimento.Entrada;

        public bool SouDeSaida()
            => Tipo == ETipoMovimento.Saida;

        public Guid Id { get; }
        public string Descricao { get; }
        public ETipoMovimento Tipo { get; }
        public decimal Valor { get; }
    }
}
