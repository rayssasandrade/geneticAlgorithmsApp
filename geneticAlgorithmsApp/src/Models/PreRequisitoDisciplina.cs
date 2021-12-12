using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace geneticAlgorithmsApp.src.Models
{
    public class PreRequisitoDisciplina
    {
        public int Id { get; set; }
        public string DisciplinaId { get; set; }
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }
        public string RequisitoDisciplinaId { get; set; }
        [ForeignKey("RequisitoDisciplinaId")]
        public Disciplina RequisitoDisciplina { get; set; }
        public string AnoPPC { get; set; }
    }
}
