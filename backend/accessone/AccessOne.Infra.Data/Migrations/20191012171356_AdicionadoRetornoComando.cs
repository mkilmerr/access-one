using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessOne.Infra.Data.Migrations
{
    public partial class AdicionadoRetornoComando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Retorno",
                table: "Comando",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Retorno",
                table: "Comando");
        }
    }
}
