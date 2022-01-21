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
            var semestres = (chromosome as HorarioChromosome).Horarios;
            int qtdCreditos = QtdCreditosAluno();
            List<Disciplina> displinasSemestre = null;
            //pegar as disciplinas que o aluno já fez
            List<Disciplina> disciplinasRealizadas = GetDisciplinasRealizadas();
            List<Disciplina> disciplinasRealizadasSemestre = null;
            foreach (var semetre in semestres)
            {
                displinasSemestre = semetre.disciplinasSemestre.ToList();
                int qtdCreditosSemestre = 0;
                disciplinasRealizadasSemestre.Clear();
                foreach (var disciplina in displinasSemestre)
                {
                    //retirar os horarios que o aluno não irá ter crédito
                    if (disciplina.QtdPreRequisitosCreditos > qtdCreditos)
                    {
                        score += (disciplina.QtdPreRequisitosCreditos - qtdCreditos) * -1;
                    }
                    //retirar as disciplinas que o aluno ainda não fez
                    if (disciplina.PreRequisitoDisciplinas.Count() > 0 && FezDiscplinasPreRequeridas(disciplina, disciplinasRealizadas) == false)
                    {
                        score += disciplina.PreRequisitoDisciplinas.Count() * -1;
                    }
                    //(vendo se o semestre da discplina pré requerida está menor que o semestre atual)
                    //ver se tem todas as discplinas que falta o aluno fazer
                    qtdCreditosSemestre += disciplina.QtdCreditos;
                    //obs: tem que ver tb se os creditos não foi os desse semestre, que o aluno ainda não tem
                }
                qtdCreditos += qtdCreditosSemestre;
                disciplinasRealizadas.AddRange(disciplinasRealizadasSemestre);

            }

            return Math.Pow(Math.Abs(score), -1);
        }

        private bool FezDiscplinasPreRequeridas(Disciplina disciplina, List<Disciplina> disciplinasRealizadas)
        {
            int cont = 0;
            foreach (var value in disciplina.PreRequisitoDisciplinas.ToList())
            {
                if (disciplinasRealizadas.Contains(_dataContext.Disciplinas.Find(value.DisciplinaId)))
                {
                    cont += 1;
                } else {
                    return false;
                }
            }
            if(cont == disciplina.PreRequisitoDisciplinas.Count())
            {
                return true;
            }
            return false;
        }

        private int QtdCreditosAluno()
        {
            var creditos = 0;
            var disciplinasRealizadas = _dataContext.Usuarios.Find('1').DisciplinasRealizadas.ToList();
            foreach (var value in disciplinasRealizadas)
            {
                creditos += value.QtdCreditos;
            }
            return creditos;
        }

        private List<Disciplina> GetDisciplinasRealizadas()
        {
            return null;
        }
    }
}
