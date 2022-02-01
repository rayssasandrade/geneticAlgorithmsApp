using geneticAlgorithmsApp.src.Models;
using System;
using System.Collections.Generic;
struct ParteHorarioChromosome
{
    public string Id { get; set; }
    public String Descricao { get; set; }
    public List<Disciplina> disciplinasSemestre { get; set; }
}