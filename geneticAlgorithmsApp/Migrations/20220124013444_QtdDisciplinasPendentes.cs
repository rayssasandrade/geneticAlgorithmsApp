using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class QtdDisciplinasPendentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_UsuarioId1",
                table: "Disciplinas",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Usuarios_UsuarioId1",
                table: "Disciplinas",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Usuarios_UsuarioId1",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_UsuarioId1",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Disciplinas");
        }
    }
}
