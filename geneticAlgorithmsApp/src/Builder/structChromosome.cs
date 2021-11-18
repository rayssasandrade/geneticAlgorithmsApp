using geneticAlgorithmsApp.src.Models;
using System;
using System.Collections.Generic;
struct ParteHorarioChromosome
{
    public int Dia { get; set; }
    public TimeSpan HorarioInicio { get; set; }
    public TimeSpan HorarioFim { get; set; }
    public string LocalId { get; set; }
    public string CursoId { get; set; }
    public string ProfessorId { get; set; }
    public string DisciplinaId { get; set; }
}