using Faturamento.Dominio.Caixas;
using Faturamento.Dominio.Definicoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace Faturamento.Testes
{
    [TestClass]
    public class Caixa_Testes
    {
        /*
         * Teste do método de abertura do caixa
         */
        public static IEnumerable<object[]> GetDadosTeste_Abrir()
        {
            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10, "Teste", EStatusCaixa.Fechado)
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10, "Teste", EStatusCaixa.Aberto)
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDadosTeste_Abrir), DynamicDataSourceType.Method)]
        public void Abrir_Testes(Caixa caixa)
        {
            caixa.Abrir();

            caixa.Status.ShouldBe(EStatusCaixa.Aberto);
        }

        /*
         * Teste do método de fechamento do caixa
         */

        public static IEnumerable<object[]> GetDadosTeste_Fechar()
        {
            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10, "Teste", EStatusCaixa.Fechado)
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10, "Teste", EStatusCaixa.Aberto)
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDadosTeste_Fechar), DynamicDataSourceType.Method)]
        public void Fechar_Testes(Caixa caixa)
        {
            caixa.Fechar();

            caixa.Status.ShouldBe(EStatusCaixa.Fechado);
        }

        /*
         * Teste do método de adição de valor
         */

        public static IEnumerable<object[]> GetDadosTeste_AdicionarValor()
        {
            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Aberto),
                10M,
                20M
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Fechado),
                10M,
                10M
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Aberto),
                0M,
                10M
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Aberto),
                -1M,
                10M
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDadosTeste_AdicionarValor), DynamicDataSourceType.Method)]
        public void Adicionar_Testes(Caixa caixa, decimal valor, decimal resultado)
        {
            caixa.AdicionarValor(valor);

            caixa.SaldoAtual.ShouldBe(resultado);
        }

        public static IEnumerable<object[]> GetDadosTeste_SubtrairValor()
        {
            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Aberto),
                5M,
                5M
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Fechado),
                5M,
                10M
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Aberto),
                0M,
                10M
            };

            yield return new object[]
            {
                new Caixa(Guid.NewGuid(), 10M, "Teste", EStatusCaixa.Aberto),
                -1M,
                10M
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDadosTeste_SubtrairValor), DynamicDataSourceType.Method)]
        public void Subtrair_Testes(Caixa caixa, decimal valor, decimal resultado)
        {
            caixa.SubtrairValor(valor);

            caixa.SaldoAtual.ShouldBe(resultado);
        }
    }
}
