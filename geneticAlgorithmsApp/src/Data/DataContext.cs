using geneticAlgorithmsApp.src.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
namespace geneticAlgorithmsApp.src.Data
{
    class DataContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MatriculaDisciplina> MatriculaDisciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["BancoDados"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreRequisitoDisciplina>()
            .HasOne(p => p.Disciplina)
            .WithMany(b => b.PreRequisitoDisciplinas)
            .HasForeignKey("RequisitoDisciplinaId");

            modelBuilder.Entity<PreRequisitoDisciplina>()
           .HasOne(p => p.Disciplina)
           .WithMany(b => b.PreRequisitoDisciplinas)
           .HasForeignKey("DisciplinaId");
        }
    }
}
