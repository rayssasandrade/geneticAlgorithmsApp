using System;
using System.Collections;
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
                displinasSemestre = semetre.disciplinasSemestre;
                int qtdCreditosSemestre = 0;

                var ds = displinasSemestre
                    .GroupBy(d => d.Nome)
                    .Where(ds => ds.Count() > 1)
                    .Select(d => new { Id = d.Key, Qtd = d.Count() });
                if (ds.Count() > 0)
                {
                    score = 0;
                    return score;
                }

                foreach (var disciplina in displinasSemestre)
                {
                    //retirar os horarios que o aluno não irá ter crédito
                    if (qtdCreditos < disciplina.QtdPreRequisitosCreditos )
                    {
                        score = 0;//disciplina.QtdPreRequisitosCreditos - qtdCreditos;
                        return score;
                    }

                    if (disciplinasRealizadas.Exists(dr => dr.Id == disciplina.Id))
                    {
                        score = 0;
                    return score;
                    }

                    //retirar as que ele ainda não tem o pre requisito necessário (não tem a disciplina de prerequisito)
                    if (FezDiscplinasPreRequeridas(disciplina, disciplinasRealizadas) == false)
                    {
                        score = 0;// disciplina.PreRequisitoDisciplinas.Count();
                    return score;
                    }



                    //(vendo se o semestre da discplina pré requerida está menor que o semestre atual)
                    //ver se tem todas as discplinas que falta o aluno fazer

                    //obs: tem que ver tb se os creditos não foi os desse semestre, que o aluno ainda não tem
                    qtdCreditosSemestre += disciplina.QtdCreditos;
                }
                qtdCreditos += qtdCreditosSemestre;

                //Incluo na variável temporária as disciplinas da foto com aquelas que ele já fez.
                disciplinasRealizadas.AddRange(semetre.disciplinasSemestre);

                score -= 0.3 * (displinasSemestre.Count-1);


            }
            score -= 0.1 * (semestres.Count-1);
            if (chromo.Usuario.QtdCreditosAluno + chromo.Usuario.QtdCreditosPendentes == qtdCreditos)
            {
                var pow = Math.Pow(Math.Abs(score), -1);
                return pow;
            }
            var pow1 = 0;// Math.Pow(Math.Abs(score), -1);
                return pow1;
        }
        private IDictionary<string, List<PreRequisitoDisciplina>> _preRequisitos =  new Dictionary<string, List<PreRequisitoDisciplina>>();
        private bool FezDiscplinasPreRequeridas(Disciplina disciplina, List<Disciplina> disciplinasRealizadas)
        {
            if ( ! _preRequisitos.ContainsKey(disciplina.Id))
            {
                _preRequisitos[disciplina.Id] = disciplina.PreRequisitoDisciplinas.Where(c => c.DisciplinaId.Equals(disciplina.Id)).ToList();
            }
            var preRequisitos = _preRequisitos[disciplina.Id];
            if (preRequisitos == null || preRequisitos.Count() == 0) return true;


            int cont = 0;
            foreach (var value in disciplina.PreRequisitoDisciplinas)
            {
                if (disciplinasRealizadas.Contains(value.RequisitoDisciplina))
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
