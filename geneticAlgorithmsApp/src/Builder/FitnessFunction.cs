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
        private readonly DataContext _dataContext;

        public double Evaluate(IChromosome chromosome)
        {
            double score = 1;
            int creditos = 0;
            var semestres = (chromosome as HorarioChromosome).Horarios;
            int qtdCreditos = qtdCreditosAluno();
            foreach (var semetre in semestres)
            {
                var displinasSemestre = semetre.disciplinasSemestre.ToList();
                foreach (var disciplina in displinasSemestre)
                {
                    //retirar os horarios que o aluno não irá ter crédito
                    if (disciplina.QtdPreRequisitosCreditos > qtdCreditos)
                    {
                        score += -1000;
                    }
                    //retirar as disciplinas que o aluno ainda não fez
                    //(vendo se o semestre da discplina pré requerida está menor que o semestre atual)
                    //ver se tem todas as discplinas que falta o aluno fazer
                    //
                }
            }

            return Math.Pow(Math.Abs(score), -1);
        }

        private int qtdCreditosAluno()
        {
            var creditos = 0;
            var disciplinasRealizadas = _dataContext.Usuarios.Find('1').DisciplinasRealizadas.ToList();
            foreach (var value in disciplinasRealizadas)
            {
                creditos += value.QtdCreditos;
            }
            return creditos;
        }

    }
}
