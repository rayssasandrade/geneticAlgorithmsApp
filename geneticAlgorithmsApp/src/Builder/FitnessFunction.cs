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
            var semestres = chromo.Horario;

            var qtdCreditos = chromo.Usuario.QtdCreditosAluno;
            List<Disciplina> displinasSemestre = null;
            List<Disciplina> disciplinasRealizadasSemestre = new List<Disciplina>();

            //pegar as disciplinas que o aluno já fez
            List<Disciplina> disciplinasRealizadas = new List<Disciplina>(chromo.Usuario.DisciplinasRealizadas);

            foreach (var semetre in semestres)
            {
                displinasSemestre = semetre.disciplinasSemestre;
                int qtdCreditosSemestre = 0;

                foreach (var disciplina in displinasSemestre)
                {
                    //retirar os horarios que o aluno não irá ter crédito
                    if (qtdCreditos <= disciplina.QtdPreRequisitosCreditos)
                    {
                        score -= (0.02 * (disciplina.QtdPreRequisitosCreditos - qtdCreditos));
                    }

                    //retirar as que ele ainda não tem o pre requisito necessário (não tem a disciplina de prerequisito)
                    if (FezDiscplinasPreRequeridas(disciplina, disciplinasRealizadas) == false)
                    {
                        score -= (0.1 * disciplina.PreRequisitoDisciplinas.Count());
                    }
                                        
                    qtdCreditosSemestre += disciplina.QtdCreditos;
                }
                qtdCreditos += qtdCreditosSemestre;

                //Incluo na variável temporária as disciplinas da foto com aquelas que ele já fez.
                disciplinasRealizadas.AddRange(semetre.disciplinasSemestre);

            }

            //ver se tem todas as discplinas que falta o aluno fazer
            int disciplinasfaltantes = DisciplinasFaltantes(disciplinasRealizadas, chromo);
            if (disciplinasfaltantes > 0)
            {
               score = 0.0001;
            }
             
            score -= 0.001 * (semestres.Count - 1);
            return score; //Math.Pow(Math.Abs(score), -1);
        }

        private int DisciplinasFaltantes(List<Disciplina> disciplinasRealizadas, HorarioChromosome chromo)
        {
            //pegar as disciplinas que o aluno já fez
            List<Disciplina> disciplinasPendentes = new List<Disciplina>(chromo.Usuario.DisciplinasPendentes);
            int cont = 0;
            foreach (var disciplina in disciplinasPendentes)
            {
                if (!disciplinasRealizadas.Contains(disciplina))
                {
                    cont += 1;
                }
            }
            return cont;
        }

        private static IDictionary<string, List<PreRequisitoDisciplina>> _preRequisitos = new Dictionary<string, List<PreRequisitoDisciplina>>();
        private bool FezDiscplinasPreRequeridas(Disciplina disciplina, List<Disciplina> disciplinasRealizadas)
        {
            if (!_preRequisitos.ContainsKey(disciplina.Id))
            {
                _preRequisitos[disciplina.Id] = disciplina.PreRequisitoDisciplinas.Where(c => c.DisciplinaId.Equals(disciplina.Id)).ToList();
            }
            var preRequisitos = _preRequisitos[disciplina.Id];
            if (preRequisitos == null || preRequisitos.Count() == 0) return true;

            var cont = 0;
            foreach (var value in disciplina.PreRequisitoDisciplinas)
            {
                if (disciplinasRealizadas.Any(x => x.Id.Equals(value.RequisitoDisciplina.Id, StringComparison.InvariantCultureIgnoreCase)))
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

        /// <summary>
        /// Melhorar este método, está consumindo muito tempo
        /// </summary>
        /// <param name="chromosome"></param>
        /// <returns></returns>
        public static Disciplina TemDuplicidade(HorarioChromosome chromosome)
        {
            IDictionary<string, byte> disciplinas = new Dictionary<string, byte>();
            foreach (var s in chromosome.Horario)
            {
                foreach (var d in s.disciplinasSemestre)
                {
                    if (disciplinas.ContainsKey(d.Id)) return d;
                    disciplinas.Add(d.Id, 1);
                }
            }
            return null;
        }
    }
}
