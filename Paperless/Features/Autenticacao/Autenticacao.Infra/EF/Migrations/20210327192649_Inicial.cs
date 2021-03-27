using Microsoft.EntityFrameworkCore.Migrations;

namespace Autenticacao.Infra.EF.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioDoSistema",
                columns: table => new
                {
                    UsuarioIdentificador = table.Column<string>(nullable: false),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    EhUsuarioAtivo = table.Column<bool>(nullable: false),
                    Perfil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDoSistema", x => x.UsuarioIdentificador);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDoSistema");
        }
    }
}
