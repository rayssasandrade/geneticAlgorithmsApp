using geneticAlgorithmsApp.src.Models;
using System;
using System.Collections.Generic;
struct HorarioChromosome
{
    public List<Turma> Turmas { get; set; }
    public List<DayOfWeek> DiasDaSemana { get; set; }
}