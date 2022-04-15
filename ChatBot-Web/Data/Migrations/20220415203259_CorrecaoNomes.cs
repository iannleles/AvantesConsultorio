using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatBot_Web.Data.Migrations
{
    public partial class CorrecaoNomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Enderecos_EnderecoId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Especialidade_EspecialidadeId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_UFs_UFSiglaUFId",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFs",
                table: "UFs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "UFs",
                newName: "UF");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "Paciente");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "Agendamento");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_UFSiglaUFId",
                table: "Endereco",
                newName: "IX_Endereco_UFSiglaUFId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamento",
                newName: "IX_Agendamento_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_EspecialidadeId",
                table: "Agendamento",
                newName: "IX_Agendamento_EspecialidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_EnderecoId",
                table: "Agendamento",
                newName: "IX_Agendamento_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UF",
                table: "UF",
                column: "UFId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paciente",
                table: "Paciente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamento",
                table: "Agendamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Endereco_EnderecoId",
                table: "Agendamento",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Especialidade_EspecialidadeId",
                table: "Agendamento",
                column: "EspecialidadeId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Paciente_PacienteId",
                table: "Agendamento",
                column: "PacienteId",
                principalTable: "Paciente",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Endereco_EnderecoId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Especialidade_EspecialidadeId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Paciente_PacienteId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_UF_UFSiglaUFId",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UF",
                table: "UF");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paciente",
                table: "Paciente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamento",
                table: "Agendamento");

            migrationBuilder.RenameTable(
                name: "UF",
                newName: "UFs");

            migrationBuilder.RenameTable(
                name: "Paciente",
                newName: "Pacientes");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Agendamento",
                newName: "Agendamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_UFSiglaUFId",
                table: "Enderecos",
                newName: "IX_Enderecos_UFSiglaUFId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_EspecialidadeId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_EspecialidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_EnderecoId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFs",
                table: "UFs",
                column: "UFId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Enderecos_EnderecoId",
                table: "Agendamentos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Especialidade_EspecialidadeId",
                table: "Agendamentos",
                column: "EspecialidadeId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_UFs_UFSiglaUFId",
                table: "Enderecos",
                column: "UFSiglaUFId",
                principalTable: "UFs",
                principalColumn: "UFId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
