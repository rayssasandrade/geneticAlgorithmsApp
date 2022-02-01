using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using geneticAlgorithmsApp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace geneticAlgorithmsApp.src.Builder
{
    class HorarioChromosome : ChromosomeBase
    {
        /// <summary>
        /// Máximo de disciplinas permitidas pelo IFS.
        /// </summary>
        /// <remarks>
        /// São no máx 15 tempos por dia (15 hr).
        /// Levando em consideração que o aluno pode pegar aulas pela manhã, tarde e noite,
        /// ele teria 15 * 5 dias. Sabendo que em média temos 4 créditos por disciplina,
        /// o aluno pode pegar, no max 18 disciplnas por semestre, visto que, 15 * 5 / 4 = 18.75 
        /// </remarks>
        public int MaxQtdDisciplinasDoSemestre { get; set; }
        public Usuario Usuario {
            get;
            private set;
        }
        private readonly DataContext _dataContext;
        static Random Random = new Random();

        //public List<List<Disciplina>> Value;
        public List<Semestre> Horarios = new List<Semestre>();

        public HorarioChromosome(DataContext dataContext, Usuario usuario, int maxQtdDisciplinasDoSemestre = 8)
        {
            _dataContext = dataContext;
            Usuario = usuario;
            this.MaxQtdDisciplinasDoSemestre = maxQtdDisciplinasDoSemestre;
            Generate();
        }
        public HorarioChromosome()
        {
            throw new Exception();
        }
        public HorarioChromosome(DataContext dataContext, Usuario usuario, List<Semestre> partesRecomendacao )
        {
            _dataContext = dataContext;
            Usuario = usuario;
            Horarios = partesRecomendacao.ToList();
        }

        public override void Generate()
        {
            //adiciona disciplinas aleatórias em uma quantidade também aleatória por semestre
            //máximo permitido pelo Curso
            //TO DO: corrigir essa quantidade máxima

            //retirar as displinas que o aluno já fez
            var disciplinasQueFaltam = Usuario.DisciplinasPendentes.ToList();

            int qtdDisciplinasQueFaltam = disciplinasQueFaltam.Count();
            int qtdSemestre = Random.Next(1, qtdDisciplinasQueFaltam);
            int i = 1;
            while (qtdDisciplinasQueFaltam > 0)
            {
                int qtdDisciplinasNoSemestre = Random.Next(1, Math.Min(qtdDisciplinasQueFaltam, MaxQtdDisciplinasDoSemestre));
                Semestre semestre = new Semestre();
                Horarios.Add(semestre);
                semestre.Descricao = i++.ToString();
                for (int j = 0; j < qtdDisciplinasNoSemestre; j++)
                {

                    var idxDisciplina = Random.Next(0, qtdDisciplinasQueFaltam);
                    var disciplinaAleatoria = disciplinasQueFaltam[idxDisciplina];
                    disciplinasQueFaltam.RemoveAt(idxDisciplina);
                    qtdDisciplinasQueFaltam--;
                    semestre.disciplinasSemestre.Add(disciplinaAleatoria);
                }
            }
        }

        public override IChromosome Clone()
        {
            return new HorarioChromosome(_dataContext, Usuario, Horarios);
        }

        public override IChromosome CreateNew()
        {
            var recomendacaoChromosome = new HorarioChromosome(_dataContext, Usuario);
            recomendacaoChromosome.Generate();
            return recomendacaoChromosome;
        }

        public override void Crossover(IChromosome pair)
        {
            var otherChromsome = pair as HorarioChromosome;
            int qtdMin = Math.Min(Horarios.Count, otherChromsome.Horarios.Count);
            var randomVal = Random.Next(qtdMin);
            for (int index = randomVal; index < qtdMin; index++)
            {
                removerDisciplina(Horarios, otherChromsome.Horarios[index]);
                Horarios[index] = otherChromsome.Horarios[index];
                if (Horarios[index].disciplinasSemestre.Count == 0)
                {
                    Horarios.RemoveAt(index);
                }
            } 
        }

        private void removerDisciplina(List<Semestre> horario, Semestre semestres)
        {
            foreach (var disciplina in semestres.disciplinasSemestre)
            {
                for(int i = 0; i < horario.Count; i++)
                {
                    for(int j = 0; j < horario[i].disciplinasSemestre.Count; j++)
                    {
                        if (horario[i].disciplinasSemestre[j].Id.Equals(disciplina.Id))
                        {
                            horario[i].disciplinasSemestre.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
        }

        public override void Mutate()
        {
            var disciplinasQueFaltam = Usuario.DisciplinasPendentes;

            int idxRecomendacao = Random.Next(disciplinasQueFaltam.Count() - 1);
            int i = 0;
            while ( i++ < 3)
            {
                int semestreA = Random.Next(Horarios.ToList().Count - 1);
                int semestreB = Random.Next(Horarios.ToList().Count - 1);

                int idxDisciplinaA = Random.Next(Horarios[semestreA].disciplinasSemestre.Count - 1);
                int idxDisciplinaB = Random.Next(Horarios[semestreB].disciplinasSemestre.Count - 1);

                var discA = Horarios[semestreA].disciplinasSemestre[idxDisciplinaA];
                var discB = Horarios[semestreB].disciplinasSemestre[idxDisciplinaB];
                Horarios[semestreA].disciplinasSemestre[idxDisciplinaA] = discB;
                Horarios[semestreB].disciplinasSemestre[idxDisciplinaB] = discA;
            }
        }
    }
}
