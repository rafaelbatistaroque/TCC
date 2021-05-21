using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arquivo.Infra.EF.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    AnoReferencia = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    MesReferencia = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    TipoArquivo = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    TipoArquivoNome = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Extensao = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");
        }
    }
}
