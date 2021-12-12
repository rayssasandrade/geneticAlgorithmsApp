using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace geneticAlgorithmsApp.src.Models
{
    public class Turma
    {
        /*Levando em consideração turmas com apeneas uma vez na semana, não tendo a divisão do horário em duas vezes na semana*/
        public string Id { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFim { get; set; }
        public string LocalId { get; set; }
        [ForeignKey("LocalId")]
        public Local Local { get; set; }
        public string CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public string ProfessorId { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }
        public string DisciplinaId { get; set; }
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }
        public String PeriodoLetivo { get; set; }

    }
}