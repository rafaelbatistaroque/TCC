using Microsoft.EntityFrameworkCore.Migrations;

namespace Arquivo.Infra.EF.Migrations
{
    public partial class arefatorado_colunas_informacoes_anexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoArquivo",
                table: "Arquivo");

            migrationBuilder.DropColumn(
                name: "TipoArquivoNome",
                table: "Arquivo");

            migrationBuilder.RenameColumn(
                name: "Extensao",
                table: "Arquivo",
                newName: "AnexoExtensao");

            migrationBuilder.AlterColumn<string>(
                name: "AnexoCodigo",
                table: "Arquivo",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "AnexoExtensao",
                table: "Arquivo",
                type: "varchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "AnexoTipo",
                table: "Arquivo",
                type: "int",
                maxLength: 1,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnexoTipo",
                table: "Arquivo");

            migrationBuilder.RenameColumn(
                name: "AnexoExtensao",
                table: "Arquivo",
                newName: "Extensao");

            migrationBuilder.AlterColumn<string>(
                name: "AnexoCodigo",
                table: "Arquivo",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extensao",
                table: "Arquivo",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoArquivo",
                table: "Arquivo",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoArquivoNome",
                table: "Arquivo",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
