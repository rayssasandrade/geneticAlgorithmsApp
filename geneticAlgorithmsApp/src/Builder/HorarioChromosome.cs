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
        /// Máximo de disciplinas permitidas pelo IFS.
        /// São no máx 15 tempos por dia (15 hr).
        /// Levando em consideração que o aluno pode pegar aulas pela manhã, tarde e noite,
        /// ele teria 15 * 5 dias. Sabendo que em média temos 4 créditos por disciplina,
        /// o aluno pode pegar, no max 18 disciplnas por semestre, visto que, 15 * 5 / 4 = 18.75
        public int MaxQtdDisciplinasDoSemestre { get; set; }
        public Usuario Usuario {
            get;
            private set;
        }
        private readonly DataContext _dataContext;
        static Random Random = new Random();
        public List<Semestre> Horarios = new List<Semestre>();

        public HorarioChromosome(DataContext dataContext, Usuario usuario, int maxQtdDisciplinasDoSemestre = 8)
        {
            _dataContext = dataContext;
            Usuario = usuario;
            this.MaxQtdDisciplinasDoSemestre = maxQtdDisciplinasDoSemestre;
            Generate();
        }
        public HorarioChromosome(DataContext dataContext, Usuario usuario, List<Semestre> partesRecomendacao )
        {
            _dataContext = dataContext;
            Usuario = usuario;
            Horarios = partesRecomendacao.ToList();
        }

        //adiciona disciplinas aleatórias em uma quantidade também aleatória por semestre
        //máximo permitido pelo IFS
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
            removerVazios(Horarios);
        }

        public override IChromosome Clone()
        {
            return new HorarioChromosome(_dataContext, Usuario, Horarios);
        }

        public override IChromosome CreateNew()
        {
            var recomendacaoChromosome = new HorarioChromosome(_dataContext, Usuario);
            //recomendacaoChromosome.Generate();
            return recomendacaoChromosome;
        }
        public override void Crossover(IChromosome pair)
        {
            var otherChromsome = pair as HorarioChromosome;
            int qtdMin = Math.Min(Horarios.Count, otherChromsome.Horarios.Count);
            var randomVal = Random.Next(qtdMin);
            for (int i = randomVal; i < qtdMin; i++)
            {
                for (int j = 0; j < otherChromsome.Horarios[i].disciplinasSemestre.Count; j++)
                {
                    Disciplina substituta = otherChromsome.Horarios[i].disciplinasSemestre[j];
                    if (Horarios[i].disciplinasSemestre.Count - 1 >= j)
                    {
                        Disciplina substituida = Horarios[i].disciplinasSemestre[j];
                        substituir(Horarios, substituta, substituida);
                        Horarios[i].disciplinasSemestre[j] = substituta;
                    } else
                    {
                        removerDisciplina(Horarios, substituta);
                        Horarios[i].disciplinasSemestre.Add(substituta);
                    }
                }
            }
            removerVazios(Horarios);
        }

        private void removerVazios(List<Semestre> horarios)
        {
            int i = 0;
            while (horarios.Count > i)
            {
                if (horarios[i].disciplinasSemestre.Count <= 0)
                {
                    horarios.RemoveAt(i);
                } else
                {
                    i++;
                }
            }
        }

        private void removerDisciplina(List<Semestre> horarios, Disciplina substituta)
        {
            for (int i = 0; i < horarios.Count; i++)
            {
                for (int j = 0; j < horarios[i].disciplinasSemestre.Count; j++)
                {
                    if (horarios[i].disciplinasSemestre[j].Equals(substituta))
                    {
                        horarios[i].disciplinasSemestre.RemoveAt(j);
                        break;
                    }
                }
            }
        }

        private void substituir(List<Semestre> horarios, Disciplina substituta, Disciplina substituida)
        {
            for (int i = 0; i < horarios.Count; i++)
            {
                for (int j = 0; j < horarios[i].disciplinasSemestre.Count; j++)
                {
                    if (horarios[i].disciplinasSemestre[j].Equals(substituta))
                    {
                        horarios[i].disciplinasSemestre[j] = substituida;
                        break;
                    }
                }
            }
        }

        public override void Mutate()
        {
            removerVazios(Horarios);
            if (Horarios.ToList().Count > 0)
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
