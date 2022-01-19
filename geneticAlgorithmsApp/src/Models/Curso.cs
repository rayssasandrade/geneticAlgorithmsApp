using System;
using System.Collections.Generic;

namespace geneticAlgorithmsApp.src.Models
{
    public class Curso 
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        //public List<Turma> Turmas { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public int MaxTempoDia { get; set; }
    }
}
