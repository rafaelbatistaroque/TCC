using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arquivo.Infra.EF.Migrations
{
    public partial class alterando_campos_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataCadastro",
                table: "Arquivo",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Arquivo",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }
    }
}
