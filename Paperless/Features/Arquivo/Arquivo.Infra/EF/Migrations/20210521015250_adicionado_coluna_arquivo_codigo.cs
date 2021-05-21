using Microsoft.EntityFrameworkCore.Migrations;

namespace Arquivo.Infra.EF.Migrations
{
    public partial class adicionado_coluna_arquivo_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnexoCodigo",
                table: "Arquivo",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnexoCodigo",
                table: "Arquivo");
        }
    }
}
