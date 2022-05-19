using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;
using Faturamento.Dominio.ServicosDeDominio.Movimentos;
using Faturamento.Dominio.ServicosDeDominio.Operacoes;
using System.Threading.Tasks;

namespace Faturamento.Dominio.ServicosDeDominio.Transferencias
{
    public sealed class EfetuarTransferenciaServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IOperacoesRepositorio _operacoesRepositorio;

        public EfetuarTransferenciaServico(ICaixaRepositorio caixaRepositorio, IOperacoesRepositorio operacoesRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _operacoesRepositorio = operacoesRepositorio;
        }

        public async Task Executar(EfetuarTransferenciaComando comando)
        {
            var caixaOrigem = await _caixaRepositorio.RecuperarCaixaAsync(comando.CaixaOrigemId);
            var caixaDestino = await _caixaRepositorio.RecuperarCaixaAsync(comando.CaixaDestinoId);

            var transferencia = Transferencia
                .Nova(caixaOrigem, caixaDestino)
                .Efetuar(comando.Valor, comando.Descricao);

            await _operacoesRepositorio.GravarAsync(transferencia);
        }
    }
}
