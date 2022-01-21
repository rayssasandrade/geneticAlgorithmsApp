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
            var chromo = chromosome as HorarioChromosome;
            var semestres = chromo.Horarios;
            
            foreach (var semetre in semestres)
            {
                var displinasSemestre = semetre.disciplinasSemestre.ToList();
                foreach (var disciplina in displinasSemestre)
                {
                    //retirar os horarios que o aluno não irá ter crédito
                    if (disciplina.QtdPreRequisitosCreditos > chromo.Usuario.QtdCreditosAluno)
                    {
                        score += -1000;
                    }
                    //retirar as disciplinas que o aluno ainda não fez
                    //(vendo se o semestre da discplina pré requerida está menor que o semestre atual)
                    //ver se tem todas as discplinas que falta o aluno fazer


                    //Acho que não falta completar a lógica.... qtdCreditos = disciplina.QtdCreditos;
                    //obs: tem que ver tb se os creditos não foi os desse semestre, que o aluno ainda não tem
                }
            }

            return Math.Pow(Math.Abs(score), -1);
        }

       

    }
}
