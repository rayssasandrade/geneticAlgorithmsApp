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
        public FitnessFunction(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public double Evaluate(IChromosome chromosome)
        {
            double score = 1;
            var chromo = chromosome as HorarioChromosome;
            var semestres = chromo.Horarios;


            var qtdCreditos = chromo.Usuario.QtdCreditosAluno;
            List<Disciplina> displinasSemestre = null;
            List<Disciplina> disciplinasRealizadasSemestre = new List<Disciplina>();


            //pegar as disciplinas que o aluno já fez
            List<Disciplina> disciplinasRealizadas = new List<Disciplina>( chromo.Usuario.DisciplinasRealizadas );
            
            foreach (var semetre in semestres)
            {
                displinasSemestre = semetre.disciplinasSemestre.ToList();
                int qtdCreditosSemestre = 0;
               
                foreach (var disciplina in displinasSemestre)
                {
                    //retirar os horarios que o aluno não irá ter crédito
                    if (disciplina.QtdPreRequisitosCreditos > qtdCreditos)
                    {
                        score -= disciplina.QtdPreRequisitosCreditos - qtdCreditos;
                    }
                    //retirar as que ele ainda não tem o pre requisito necessário (não tem a disciplina de prerequisito)
                    if ( FezDiscplinasPreRequeridas(disciplina, disciplinasRealizadas) == false)
                    {
                        score -= disciplina.PreRequisitoDisciplinas.Count();
                    }
                    //(vendo se o semestre da discplina pré requerida está menor que o semestre atual)
                    //ver se tem todas as discplinas que falta o aluno fazer
                   
                    //obs: tem que ver tb se os creditos não foi os desse semestre, que o aluno ainda não tem
                    qtdCreditosSemestre += disciplina.QtdCreditos;
                }
                qtdCreditos += qtdCreditosSemestre;

                //Incluo na variável temporária as disciplinas da foto com aquelas que ele já fez.
                disciplinasRealizadas.AddRange(semetre.disciplinasSemestre);

            }
            score -= 0.1 * semestres.Count;

            return Math.Pow(Math.Abs(score), -1);
        }

        private bool FezDiscplinasPreRequeridas(Disciplina disciplina, List<Disciplina> disciplinasRealizadas)
        {
            List<Disciplina> preRequisitos = (List<Disciplina>)disciplina.PreRequisitoDisciplinas.ToList().Where(c => c.DisciplinaId.Equals(disciplina.Id));
            if (disciplina.PreRequisitoDisciplinas.ToList() == null || disciplina.PreRequisitoDisciplinas.ToList().Count() == 0) return true;

            int cont = 0;
            foreach (var value in disciplina.PreRequisitoDisciplinas.ToList())
            {
                if (disciplinasRealizadas.Contains(_dataContext.Disciplinas.Find(value.DisciplinaId)))
                {
                    cont += 1;
                }
                else
                {
                    return false;
                }
            }
            if (cont == disciplina.PreRequisitoDisciplinas.Count())
            {
                return true;
            }
            return false;
        }
    }
}
