using Cliente.Comando.Menus.Vazio;
using System;

namespace Cliente.Comando
{
    public sealed class MenuFactory
    {
        private readonly IServiceProvider _container;

        public MenuFactory(IServiceProvider container)
        {
            _container = container;
        }

        public IComandoFactory Gerar(string menu)
        {
            switch (menu)
            {
                case "menu_inicial":
                    return new ComandoInicialFactory(_container);
                default:
                    return new ComandoVazioFactory();
            }
        }
    }
}
