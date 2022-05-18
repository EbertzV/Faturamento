using Faturamento.Dominio.Definicoes;
using System;

namespace Faturamento.Dominio.Caixas
{
    public sealed class Caixa
    {
        public Caixa(Guid id, decimal saldoAtual, string nome, EStatusCaixa status)
        {
            Id = id;
            Nome = nome;
            SaldoAtual = saldoAtual;
            Status = status;
        }

        public Guid Id { get; }
        public string Nome { get; }
        public decimal SaldoAtual { get; private set; }
        public EStatusCaixa Status { get; private set; }

        public void Abrir()
        {
            Status = EStatusCaixa.Aberto;
        }

        public void Fechar()
        {
            Status = EStatusCaixa.Fechado;
        }

        public bool AdicionarValor(decimal valor)
        {
            if (Status == EStatusCaixa.Fechado)
                return false;
            if (valor <= 0)
                return false;
            SaldoAtual += valor;
            return true;
        }

        public bool SubtrairValor(decimal valor)
        {
            if (Status == EStatusCaixa.Fechado)
                return false;
            if (valor <= 0)
                return false;
            SaldoAtual -= valor;
            return true;
        }
    }
}
