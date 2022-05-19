using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class movimento_Fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CaixaId",
                table: "Movimentos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_CaixaId",
                table: "Movimentos",
                column: "CaixaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentos_Caixas_CaixaId",
                table: "Movimentos",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentos_Caixas_CaixaId",
                table: "Movimentos");

            migrationBuilder.DropIndex(
                name: "IX_Movimentos_CaixaId",
                table: "Movimentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaixaId",
                table: "Movimentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
