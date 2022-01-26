using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace geneticAlgorithmsApp.Migrations
{
    public partial class initProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxTempoDia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.Id);
                });

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
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdCreditos = table.Column<int>(type: "int", nullable: false),
                    QtdPreRequisitosCreditos = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    AnoPPC = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SemestreId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Semestres_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semestres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuarios",
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

            migrationBuilder.CreateTable(
                name: "PreRequisitoDisciplina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplinaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequisitoDisciplinaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreRequisitoDisciplina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreRequisitoDisciplina_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreRequisitoDisciplina_Disciplinas_RequisitoDisciplinaId",
                        column: x => x.RequisitoDisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "int", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorarioFim = table.Column<TimeSpan>(type: "time", nullable: false),
                    LocalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CursoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProfessorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisciplinaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PeriodoLetivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_SemestreId",
                table: "Disciplinas",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_UsuarioId",
                table: "Disciplinas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_UsuarioId1",
                table: "Disciplinas",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDisciplinas_AlunoId",
                table: "MatriculaDisciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDisciplinas_DisciplinaId1",
                table: "MatriculaDisciplinas",
                column: "DisciplinaId1");

            migrationBuilder.CreateIndex(
                name: "IX_PreRequisitoDisciplina_DisciplinaId",
                table: "PreRequisitoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreRequisitoDisciplina_RequisitoDisciplinaId",
                table: "PreRequisitoDisciplina",
                column: "RequisitoDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CursoId",
                table: "Turmas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_DisciplinaId",
                table: "Turmas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_LocalId",
                table: "Turmas",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CursoId",
                table: "Usuarios",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatriculaDisciplinas");

            migrationBuilder.DropTable(
                name: "PreRequisitoDisciplina");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Semestres");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
