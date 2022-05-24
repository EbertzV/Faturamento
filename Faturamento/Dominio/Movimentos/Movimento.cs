using Faturamento.Dominio.Definicoes;
using System;

namespace Faturamento.Dominio.Movimentos
{
    public class Movimento
    {
        public Movimento(Guid id, string descricao, ETipoMovimento tipo, decimal valor, DateTime data)
        {
            Id = id;
            Descricao = descricao;
            Tipo = tipo;
            Valor = valor;
            Data = data;
        }

        public static Movimento NovoDeEntrada(decimal valor, DateTime data, string descricao = "")
            => new Movimento(Guid.NewGuid(), descricao, ETipoMovimento.Entrada, valor, data);

        public static Movimento NovoDeSaida(decimal valor, DateTime data, string descricao = "")
            => new Movimento(Guid.NewGuid(), descricao, ETipoMovimento.Saida, valor, data);

        public bool SouDeEntrada()
            => Tipo == ETipoMovimento.Entrada;

        public bool SouDeSaida()
            => Tipo == ETipoMovimento.Saida;

        public Guid Id { get; }
        public string Descricao { get; }
        public ETipoMovimento Tipo { get; }
        public decimal Valor { get; }
        public DateTime Data { get; }
    }
}
