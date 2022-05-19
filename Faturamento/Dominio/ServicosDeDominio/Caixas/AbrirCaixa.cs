using System;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Caixas
{
    public sealed class AbrirCaixa
    {
        private readonly ICaixaRepositorio _caixaRepositorio;

        public AbrirCaixa(ICaixaRepositorio caixaRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
        }

        public async Task Executar(Guid caixaId)
        {
            var caixa = await _caixaRepositorio.RecuperarCaixaAsync(caixaId);

            caixa.Abrir();

            await _caixaRepositorio.AtualizarAsync(caixa);
        }
    }
}
