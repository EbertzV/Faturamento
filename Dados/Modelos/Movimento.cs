using System;

namespace Dados.Modelos
{
    public sealed class Movimento
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public Caixa Caixa { get; set; }
    }
}
