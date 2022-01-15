using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace geneticAlgorithmsApp.src.Models
{
    public class Semestre
    {

        public string Id { get; set; }
        public String Nome { get; set; }
        public List<Disciplina> disciplinasSemestre { get; set; }
    }
}