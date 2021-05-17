using Microsoft.EntityFrameworkCore.Migrations;

namespace Usuario.Infra.EF.Migrations
{
    public partial class RemoverColunaPerfilNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioPerfilNome",
                table: "UsuarioDoSistema");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioPerfilNome",
                table: "UsuarioDoSistema",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
