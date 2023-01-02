using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCMAvantes.Infra.Migrations
{
    public partial class AjustesAgendamentoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Endereco",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Endereco",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Endereco");
        }
    }
}
