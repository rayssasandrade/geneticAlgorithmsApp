using System;
using System.Collections.Generic;

namespace geneticAlgorithmsApp.src.Models
{
    public class Semestre
    {
        public Semestre()
        {
            disciplinasSemestre = new List<Disciplina>();
        }
        public string Id { get; set; }
        public String Descricao { get; set; }
        public List<Disciplina> disciplinasSemestre { get; set; }
    }
}