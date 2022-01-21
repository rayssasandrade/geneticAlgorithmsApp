
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace geneticAlgorithmsApp.src.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public List<Disciplina> DisciplinasRealizadas { get; set; }

        public int QtdCreditosAluno
        {
            get
            {
                return this.DisciplinasRealizadas.Sum(x => x.QtdCreditos);
            }
        }

    }
}