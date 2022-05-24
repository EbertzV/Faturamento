using System;

namespace Dados.Modelos
{
    public sealed class Operacao
    {
        public Guid Id { get; set; }
        public Movimento Recebimento { get; set; }
        public Movimento Pagamento { get; set; }
        public Guid OperadorId { get; set; }
    }
}
