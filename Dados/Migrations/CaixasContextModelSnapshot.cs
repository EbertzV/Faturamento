﻿// <auto-generated />
using System;
using Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dados.Migrations
{
    [DbContext(typeof(CaixasContext))]
    partial class CaixasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dados.Modelos.Caixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaldoAtual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("Dados.Modelos.Movimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CaixaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.ToTable("Movimentos");
                });

            modelBuilder.Entity("Dados.Modelos.Operacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OperadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RecebimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("RecebimentoId");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("Dados.Modelos.Movimento", b =>
                {
                    b.HasOne("Dados.Modelos.Caixa", "Caixa")
                        .WithMany()
                        .HasForeignKey("CaixaId");

                    b.Navigation("Caixa");
                });

            modelBuilder.Entity("Dados.Modelos.Operacao", b =>
                {
                    b.HasOne("Dados.Modelos.Movimento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId");

                    b.HasOne("Dados.Modelos.Movimento", "Recebimento")
                        .WithMany()
                        .HasForeignKey("RecebimentoId");

                    b.Navigation("Pagamento");

                    b.Navigation("Recebimento");
                });
#pragma warning restore 612, 618
        }
    }
}
