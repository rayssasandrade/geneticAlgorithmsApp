﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using geneticAlgorithmsApp.src.Data;

namespace geneticAlgorithmsApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220123234238_preRequisito")]
    partial class preRequisito
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Curso", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaxTempoDia")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Disciplina", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AnoPPC")
                        .HasColumnType("int");

                    b.Property<string>("CursoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Periodo")
                        .HasColumnType("int");

                    b.Property<int>("QtdCreditos")
                        .HasColumnType("int");

                    b.Property<int>("QtdPreRequisitosCreditos")
                        .HasColumnType("int");

                    b.Property<string>("SemestreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("SemestreId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Local", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.MatriculaDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("DisciplinaId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId1");

                    b.ToTable("MatriculaDisciplinas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.PreRequisitoDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisciplinaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RequisitoDisciplinaId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("RequisitoDisciplinaId");

                    b.ToTable("PreRequisitoDisciplinas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Professor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Semestre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Semestres");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Turma", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CursoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DiaDaSemana")
                        .HasColumnType("int");

                    b.Property<string>("DisciplinaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("HorarioFim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time");

                    b.Property<string>("LocalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PeriodoLetivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("LocalId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CursoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Disciplina", b =>
                {
                    b.HasOne("geneticAlgorithmsApp.src.Models.Curso", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId");

                    b.HasOne("geneticAlgorithmsApp.src.Models.Semestre", null)
                        .WithMany("disciplinasSemestre")
                        .HasForeignKey("SemestreId");

                    b.HasOne("geneticAlgorithmsApp.src.Models.Usuario", null)
                        .WithMany("DisciplinasRealizadas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.MatriculaDisciplina", b =>
                {
                    b.HasOne("geneticAlgorithmsApp.src.Models.Usuario", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("geneticAlgorithmsApp.src.Models.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId1");

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.PreRequisitoDisciplina", b =>
                {
                    b.HasOne("geneticAlgorithmsApp.src.Models.Disciplina", "Disciplina")
                        .WithMany("PreRequisitoDisciplinas")
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("geneticAlgorithmsApp.src.Models.Disciplina", "RequisitoDisciplina")
                        .WithMany()
                        .HasForeignKey("RequisitoDisciplinaId");

                    b.Navigation("Disciplina");

                    b.Navigation("RequisitoDisciplina");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Turma", b =>
                {
                    b.HasOne("geneticAlgorithmsApp.src.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.HasOne("geneticAlgorithmsApp.src.Models.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("geneticAlgorithmsApp.src.Models.Local", "Local")
                        .WithMany("Turmas")
                        .HasForeignKey("LocalId");

                    b.HasOne("geneticAlgorithmsApp.src.Models.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Curso");

                    b.Navigation("Disciplina");

                    b.Navigation("Local");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Usuario", b =>
                {
                    b.HasOne("geneticAlgorithmsApp.src.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Disciplina", b =>
                {
                    b.Navigation("PreRequisitoDisciplinas");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Local", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Professor", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Semestre", b =>
                {
                    b.Navigation("disciplinasSemestre");
                });

            modelBuilder.Entity("geneticAlgorithmsApp.src.Models.Usuario", b =>
                {
                    b.Navigation("DisciplinasRealizadas");
                });
#pragma warning restore 612, 618
        }
    }
}
