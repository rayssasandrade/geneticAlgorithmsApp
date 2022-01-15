using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class retirandoAnoDoPreRequisito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoPPC",
                table: "PreRequisitoDisciplina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnoPPC",
                table: "PreRequisitoDisciplina",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
