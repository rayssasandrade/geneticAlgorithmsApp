using System;
using System.Collections.Generic;

namespace geneticAlgorithmsApp.src.Models
{
    public class Semestre
    {
        public string Id { get; set; }
        public String Descricao { get; set; }
        public List<Disciplina> disciplinasSemestre { get; set; }
    }
}