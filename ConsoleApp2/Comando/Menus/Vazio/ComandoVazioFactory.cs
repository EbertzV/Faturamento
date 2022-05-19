using System;

namespace Cliente.Comando.Menus.Vazio
{
    public sealed class ComandoVazioFactory : IComandoFactory
    {
        public IComandoHandler Gerar(string comando)
            => new ComandoVazioHandler();
    }
}
