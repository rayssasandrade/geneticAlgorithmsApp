using System;
using System.Collections.Generic;

namespace geneticAlgorithmsApp.src.Models
{
    public class Turma
    {
        public string Id { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFim { get; set; }
        public string LocalId { get; set; }
        public Local Local { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public string ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public string DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

    }
}