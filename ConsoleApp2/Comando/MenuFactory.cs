using Cliente.Comando.Menus.Vazio;
using MediatR;

namespace Cliente.Comando
{
    public sealed class MenuFactory
    {
        private readonly IMediator _mediator;

        public MenuFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IComandoFactory Gerar(string menu)
        {
            switch (menu)
            {
                case "menu_inicial":
                    return new ComandoInicialFactory(_mediator);
                default:
                    return new ComandoVazioFactory();
            }
        }
    }
}
