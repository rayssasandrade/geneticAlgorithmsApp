using geneticAlgorithmsApp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace geneticAlgorithmsApp.src.Data
{
    class DataContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Integrated Security=SSPI; Password=123; User ID=sa; Initial Catalog=GeneticAlgorithms; Data Source=LAPTOP-02VG7CTT\\SQLEXPRESS"
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().HasKey("LocalId", "CursoId", "ProfessorId", "DisciplinaId");
            modelBuilder.Entity<Curso>().HasMany(curso => curso.Turmas);
            modelBuilder.Entity<Disciplina>().HasMany(disciplina => disciplina.Turmas);
            modelBuilder.Entity<Disciplina>().HasMany(disciplina => disciplina.PreRequisitosDisciplinas);
            modelBuilder.Entity<Local>().HasMany(local => local.Turmas);
            modelBuilder.Entity<Professor>().HasMany(professor => professor.Turmas);

            base.OnModelCreating(modelBuilder);
        }
    }
}
