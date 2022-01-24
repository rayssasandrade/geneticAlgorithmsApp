using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class preRequisito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreRequisitoDisciplina_Disciplinas_DisciplinaId",
                table: "PreRequisitoDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_PreRequisitoDisciplina_Disciplinas_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreRequisitoDisciplina",
                table: "PreRequisitoDisciplina");

            migrationBuilder.RenameTable(
                name: "PreRequisitoDisciplina",
                newName: "PreRequisitoDisciplinas");

            migrationBuilder.RenameIndex(
                name: "IX_PreRequisitoDisciplina_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplinas",
                newName: "IX_PreRequisitoDisciplinas_RequisitoDisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_PreRequisitoDisciplina_DisciplinaId",
                table: "PreRequisitoDisciplinas",
                newName: "IX_PreRequisitoDisciplinas_DisciplinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreRequisitoDisciplinas",
                table: "PreRequisitoDisciplinas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PreRequisitoDisciplinas_Disciplinas_DisciplinaId",
                table: "PreRequisitoDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreRequisitoDisciplinas_Disciplinas_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplinas",
                column: "RequisitoDisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreRequisitoDisciplinas_Disciplinas_DisciplinaId",
                table: "PreRequisitoDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_PreRequisitoDisciplinas_Disciplinas_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreRequisitoDisciplinas",
                table: "PreRequisitoDisciplinas");

            migrationBuilder.RenameTable(
                name: "PreRequisitoDisciplinas",
                newName: "PreRequisitoDisciplina");

            migrationBuilder.RenameIndex(
                name: "IX_PreRequisitoDisciplinas_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplina",
                newName: "IX_PreRequisitoDisciplina_RequisitoDisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_PreRequisitoDisciplinas_DisciplinaId",
                table: "PreRequisitoDisciplina",
                newName: "IX_PreRequisitoDisciplina_DisciplinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreRequisitoDisciplina",
                table: "PreRequisitoDisciplina",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PreRequisitoDisciplina_Disciplinas_DisciplinaId",
                table: "PreRequisitoDisciplina",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreRequisitoDisciplina_Disciplinas_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplina",
                column: "RequisitoDisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
