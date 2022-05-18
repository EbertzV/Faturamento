using Faturamento.Dominio.Operacoes;
using Faturamento.Dominio.ServicosDeDominio.Caixas;

namespace Faturamento.Dominio.ServicosDeDominio.Transferencias
{
    public sealed class EfetuarTransferenciaServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly ITransferenciasRepositorio _transferenciasRepositorio;

        public EfetuarTransferenciaServico(ICaixaRepositorio caixaRepositorio, ITransferenciasRepositorio transferenciasRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
            _transferenciasRepositorio = transferenciasRepositorio;
        }

        public void Executar(EfetuarTransferenciaComando comando)
        {
            var caixaOrigem = _caixaRepositorio.RecuperarCaixa(comando.CaixaOrigemId);
            var caixaDestino = _caixaRepositorio.RecuperarCaixa(comando.CaixaDestinoId);

            var transferencia = Transferencia
                .Nova(caixaOrigem, caixaDestino)
                .Efetuar(comando.Valor, comando.Descricao);

            _transferenciasRepositorio.GravarTransferencia(transferencia);
        }
    }
}
