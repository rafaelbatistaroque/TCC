using Microsoft.EntityFrameworkCore.Migrations;

namespace Colaborador.Infra.EF.Migrations
{
    public partial class exclusao_coluna_funcao_nome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncaoNome",
                table: "Colaborador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FuncaoNome",
                table: "Colaborador",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
