using System;

namespace Cliente
{
    public interface IComandoHandler
    {
        void Executar(Guid operadorId);
    }
}
