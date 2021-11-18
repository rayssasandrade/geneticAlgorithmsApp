using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class ajusteStructChromosome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Disciplina_DisciplinaId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Curso_CursoId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Disciplina_DisciplinaId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Local_LocalId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turma",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "Local");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplina",
                table: "Disciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.RenameTable(
                name: "Turma",
                newName: "Turmas");

            migrationBuilder.RenameTable(
                name: "Professor",
                newName: "Professores");

            migrationBuilder.RenameTable(
                name: "Local",
                newName: "Locais");

            migrationBuilder.RenameTable(
                name: "Disciplina",
                newName: "Disciplinas");

            migrationBuilder.RenameTable(
                name: "Curso",
                newName: "Cursos");

            migrationBuilder.RenameIndex(
                name: "IX_Turma_ProfessorId",
                table: "Turmas",
                newName: "IX_Turmas_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Turma_DisciplinaId",
                table: "Turmas",
                newName: "IX_Turmas_DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Turma_CursoId",
                table: "Turmas",
                newName: "IX_Turmas_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplina_DisciplinaId",
                table: "Disciplinas",
                newName: "IX_Disciplinas_DisciplinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas",
                columns: new[] { "LocalId", "CursoId", "ProfessorId", "DisciplinaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locais",
                table: "Locais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplinas",
                table: "Disciplinas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Disciplinas_DisciplinaId",
                table: "Disciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Cursos_CursoId",
                table: "Turmas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Disciplinas_DisciplinaId",
                table: "Turmas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Locais_LocalId",
                table: "Turmas",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Disciplinas_DisciplinaId",
                table: "Disciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Cursos_CursoId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Disciplinas_DisciplinaId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Locais_LocalId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locais",
                table: "Locais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplinas",
                table: "Disciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.RenameTable(
                name: "Turmas",
                newName: "Turma");

            migrationBuilder.RenameTable(
                name: "Professores",
                newName: "Professor");

            migrationBuilder.RenameTable(
                name: "Locais",
                newName: "Local");

            migrationBuilder.RenameTable(
                name: "Disciplinas",
                newName: "Disciplina");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Curso");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turma",
                newName: "IX_Turma_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_DisciplinaId",
                table: "Turma",
                newName: "IX_Turma_DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_CursoId",
                table: "Turma",
                newName: "IX_Turma_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplinas_DisciplinaId",
                table: "Disciplina",
                newName: "IX_Disciplina_DisciplinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turma",
                table: "Turma",
                columns: new[] { "LocalId", "CursoId", "ProfessorId", "DisciplinaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local",
                table: "Local",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplina",
                table: "Disciplina",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Disciplina_DisciplinaId",
                table: "Disciplina",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Curso_CursoId",
                table: "Turma",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Disciplina_DisciplinaId",
                table: "Turma",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Local_LocalId",
                table: "Turma",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
