using Microsoft.EntityFrameworkCore.Migrations;

namespace GCMAvantes.Data.Migrations
{
    public partial class alterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Especialidade_EspecialidadeId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_UF_UFSiglaUFId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_UFSiglaUFId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "UFSiglaUFId",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "UFSiglaId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UFSiglaId",
                table: "Endereco",
                column: "UFSiglaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Especialidade_EspecialidadeId",
                table: "Agendamento",
                column: "EspecialidadeId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_UF_UFSiglaId",
                table: "Endereco",
                column: "UFSiglaId",
                principalTable: "UF",
                principalColumn: "UFId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Especialidade_EspecialidadeId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_UF_UFSiglaId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_UFSiglaId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "UFSiglaId",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "UFSiglaUFId",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeId",
                table: "Agendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UFSiglaUFId",
                table: "Endereco",
                column: "UFSiglaUFId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Especialidade_EspecialidadeId",
                table: "Agendamento",
                column: "EspecialidadeId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_UF_UFSiglaUFId",
                table: "Endereco",
                column: "UFSiglaUFId",
                principalTable: "UF",
                principalColumn: "UFId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
