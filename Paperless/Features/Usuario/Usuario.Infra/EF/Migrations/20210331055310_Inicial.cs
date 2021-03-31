using Microsoft.EntityFrameworkCore.Migrations;

namespace Usuario.Infra.EF.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioDoSistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioIdentificacao = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    UsuarioNome = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    UsuarioSenha = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    EhUsuarioAtivo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioPerfilId = table.Column<int>(type: "int", nullable: true),
                    UsuarioPerfilNome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDoSistema", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDoSistema");
        }
    }
}
