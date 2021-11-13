using System;
using System.Collections.Generic;

namespace geneticAlgorithmsApp.src.Models
{
    public class Disciplina
    {
        public string Id { get; set; }
        public String Nome { get; set; }
        public List<Disciplina> PreRequisitos { get; set; }
        public List<Turma> Turmas { get; set; }
        public int Creditos { get; set; }
        public int Periodo { get; set; }
    }
}