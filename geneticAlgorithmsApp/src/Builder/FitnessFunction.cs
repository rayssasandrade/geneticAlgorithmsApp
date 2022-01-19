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
            var semestres = (chromosome as HorarioChromosome).Horarios;
            foreach (var semetre in semestres)
            {
                var displinasSemestre = semetre.disciplinasSemestre.ToList();
                foreach (var disciplina in displinasSemestre)
                {

                }
            }

            return Math.Pow(Math.Abs(score), -1);
        }

        // buscar altura para a folha
        public int qtdDisciplinas(Disciplina disciplina){
            return disciplina.PreRequisitoDisciplinas.Count();
        }
    }
}
