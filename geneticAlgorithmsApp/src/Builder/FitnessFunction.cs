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
            var values = (chromosome as HorarioChromosome).Horarios;
            foreach (var value in values)
            {
                score += qtdDisciplinas(value);

            }

            return Math.Pow(Math.Abs(score), -1);
        }

        //altura
        public int qtdDisciplinas(Disciplina disciplina){
            return disciplina.PreRequisitoDisciplinas.Count();
        }
    }
}
