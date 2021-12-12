using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace geneticAlgorithmsApp.src.Models
{
    public class Disciplina
    {
        public string Id { get; set; }
        public String Nome { get; set; }
        public List<PreRequisitoDisciplina> PreRequisitoDisciplinas { get; set; }
        public List<Turma> Turmas { get; set; }
        public int QtdCreditos { get; set; }
        public int QtdPreRequisitosCreditos { get; set; }
        public int Periodo { get; set; }
    }
}