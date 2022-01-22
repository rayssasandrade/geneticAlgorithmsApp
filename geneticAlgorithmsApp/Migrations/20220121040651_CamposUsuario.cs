using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class CamposUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatriculaDisciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculaDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatriculaDisciplinas_Disciplinas_DisciplinaId1",
                        column: x => x.DisciplinaId1,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatriculaDisciplinas_Usuarios_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_UsuarioId",
                table: "Disciplinas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDisciplinas_AlunoId",
                table: "MatriculaDisciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDisciplinas_DisciplinaId1",
                table: "MatriculaDisciplinas",
                column: "DisciplinaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CursoId",
                table: "Usuarios",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Usuarios_UsuarioId",
                table: "Disciplinas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Usuarios_UsuarioId",
                table: "Disciplinas");

            migrationBuilder.DropTable(
                name: "MatriculaDisciplinas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_UsuarioId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Disciplinas");
        }
    }
}
