using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class CorrecaoAnoPPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnoPPC",
                table: "Disciplinas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoPPC",
                table: "Disciplinas");
        }
    }
}
