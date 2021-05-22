using Microsoft.EntityFrameworkCore.Migrations;

namespace Colaborador.Infra.EF.Migrations
{
    public partial class alterando_campos_migration_colaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Colaborador",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   PrimeiroNome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                   Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                   NumeroCPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                   FuncaoId = table.Column<int>(type: "int", nullable: true),
                   FuncaoNome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Colaborador", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
