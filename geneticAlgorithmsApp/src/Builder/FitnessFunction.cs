using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using geneticAlgorithmsApp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace geneticAlgorithmsApp.src.Builder
{
    class FitnessFunction : IFitnessFunction
    {
        public double Evaluate(IChromosome chromosome)
        {
            double score = 1;
            var values = (chromosome as HorarioChromosome).Value;
            var GetoverLaps = new Func<Turma, List<Turma>>(current => values
                .Except(new[] { current })
                .Where(slot => slot.DiaDaSemana == current.DiaDaSemana)
                .Where(slot => slot.HorarioInicio == current.HorarioInicio
                              || slot.HorarioInicio <= current.HorarioFim && slot.HorarioInicio >= current.HorarioInicio
                              || slot.HorarioFim >= current.HorarioInicio && slot.HorarioFim <= current.HorarioFim)
                .ToList());



            foreach (var value in values)
            {
                var overLaps = GetoverLaps(value);
                score -= overLaps.GroupBy(slot => slot.ProfessorId).Sum(x => x.Count() - 1);
                score -= overLaps.GroupBy(slot => slot.LocalId).Sum(x => x.Count() - 1);
                score -= overLaps.GroupBy(slot => slot.CursoId).Sum(x => x.Count() - 1);
            }

            score -= values.GroupBy(v => v.DiaDaSemana).Count() * 0.5;
            return Math.Pow(Math.Abs(score), -1);
        }
    }
}
