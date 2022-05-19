using Cliente.Comando.Menus.MenuInicial;
using Cliente.Comando.Menus.Vazio;
using System;

namespace Cliente
{
    public sealed class ComandoInicialFactory : IComandoFactory
    {
        private readonly IServiceProvider _container;

        public ComandoInicialFactory(IServiceProvider container)
        {
            _container = container;
        }

        public IComandoHandler Gerar(string comando)
        {
            switch (comando)
            {
                case "receber":
                    return new EfetuarRecebimentoComandoHandler(_container);
                case "abrir caixa":
                    return new AbrirCaixaComandoHandler(_container);
                case "pagar":
                    return new EfetuarPagamentoComandoHandler(_container);
                case "transferir":
                    return new EfetuarTransferenciaComandoHandler(_container);
                default:
                    return new ComandoVazioHandler();
            }
        }
    }
}
