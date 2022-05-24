using Infra.SqlServer.Modelos.Caixas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.SqlServer.Modelos
{
    public sealed class MovimentoDB
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public CaixaDB Caixa { get; set; }
        public DateTime Data { get; set; }
    }
}
