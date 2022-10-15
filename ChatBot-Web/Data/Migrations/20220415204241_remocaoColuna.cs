using Microsoft.EntityFrameworkCore.Migrations;

namespace GCMAvantes.Data.Migrations
{
    public partial class remocaoColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeSemAcento",
                table: "UF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeSemAcento",
                table: "UF",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
