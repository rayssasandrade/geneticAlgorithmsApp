
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace geneticAlgorithmsApp.src.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.MatriculaDisciplina = new List<MatriculaDisciplina>();
            this.DisciplinasRealizadas = new List<Disciplina>();
        }
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public List<MatriculaDisciplina> MatriculaDisciplina { get; set; }
        public IEnumerable<Disciplina> DisciplinasRealizadas { get; set; }
        public List<Disciplina> DisciplinasPendentes{ get; set; }

        public int QtdCreditosAluno
        {
            get
            {
                return this.DisciplinasRealizadas.Sum(x => x.QtdCreditos);
            }
        }
        public int QtdCreditosPendentes {
            get {
                return this.DisciplinasPendentes.Sum(x => x.QtdCreditos);
            }
        }

    }
}