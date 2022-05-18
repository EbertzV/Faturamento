using System;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public sealed class AbrirCaixa
    {
        private readonly ICaixaRepositorio _caixaRepositorio;

        public AbrirCaixa(ICaixaRepositorio caixaRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
        }

        public void Executar(Guid caixaId)
        {
            var caixa = _caixaRepositorio.RecuperarCaixa(caixaId);

            caixa.Abrir();

            _caixaRepositorio.Atualizar(caixa);
        }
    }
}
