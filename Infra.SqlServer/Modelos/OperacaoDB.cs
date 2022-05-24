using System;

namespace Infra.SqlServer.Modelos
{
    public sealed class OperacaoDB
    {
        public Guid Id { get; set; }
        public MovimentoDB Recebimento { get; set; }
        public MovimentoDB Pagamento { get; set; }
        public Guid OperadorId { get; set; }
    }
}
