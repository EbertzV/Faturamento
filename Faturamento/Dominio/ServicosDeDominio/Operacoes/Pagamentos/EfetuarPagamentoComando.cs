﻿using System;

namespace Faturamento.Dominio.ServicosDeDominio.Pagamentos
{
    public sealed class EfetuarPagamentoComando
    {
        public EfetuarPagamentoComando(Guid caixaId, decimal valor, string descricao)
        {
            CaixaId = caixaId;
            Valor = valor;
            Descricao = descricao;
        }

        public Guid CaixaId { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
    }
}