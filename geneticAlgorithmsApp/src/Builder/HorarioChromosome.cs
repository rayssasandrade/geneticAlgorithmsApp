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

        public List<ParteHorarioChromosome> Value;

        public HorarioChromosome(DataContext dataContext, Usuario usuario, int maxQtdDisciplinasDoSemestre = 8)
        {
            _dataContext = dataContext;
            Usuario = usuario;
            this.MaxQtdDisciplinasDoSemestre = maxQtdDisciplinasDoSemestre;
            Generate();
        }
        public HorarioChromosome(DataContext dataContext, Usuario usuario, List<ParteHorarioChromosome> partesRecomendacao )
        {
            _dataContext = dataContext;
            Usuario = usuario;
            Value = partesRecomendacao.ToList();
        }

        public override void Generate()
        {
            //adiciona disciplinas aleatórias em uma quantidade também aleatória por semestre
            //máximo permitido pelo Curso
            //TO DO: corrigir essa quantidade máxima

            IEnumerable<ParteHorarioChromosome> generateRandomHorarios()
            {
                //retirar as displinas que o aluno já fez
                var disciplinasQueFaltam = Usuario.DisciplinasPendentes.ToList();
                int qtdDisciplinasQueFaltam = disciplinasQueFaltam.Count();
                int qtdDisciplinasNoSemestre = Random.Next(1, Math.Min(qtdDisciplinasQueFaltam, MaxQtdDisciplinasDoSemestre));
                List<Disciplina> semestre = new List<Disciplina>();
                for (int j = 0; j < qtdDisciplinasNoSemestre; j++)
                {
                    var idxDisciplina = Random.Next(0, qtdDisciplinasQueFaltam);
                    var disciplinaAleatoria = disciplinasQueFaltam[idxDisciplina];
                    disciplinasQueFaltam.RemoveAt(idxDisciplina);
                    qtdDisciplinasQueFaltam--;
                    semestre.Add(disciplinaAleatoria);
                }

                string descricao = "";
                if (Value == null)
                {
                    descricao = "1";
                } else
                {
                    descricao = Value.Count.ToString();
                }

                yield return new ParteHorarioChromosome() {
                    Descricao = descricao,
                    disciplinasSemestre = semestre.ToList()
                };
            }

            Value = generateRandomHorarios().ToList();
        }

        public override IChromosome Clone()
        {
            return new HorarioChromosome(_dataContext, Usuario, Value);
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
            int qtdMin = Math.Min(Value.Count, otherChromsome.Value.Count);
            var randomVal = Random.Next(qtdMin);
            for (int index = randomVal; index < qtdMin; index++)
            {
                Value[index] = otherChromsome.Value[index];
            }
        }

        public override void Mutate()
        {
            var disciplinasQueFaltam = Usuario.DisciplinasPendentes;

            //alteatoriamente selecionei um semestre, retirei uma disciplina  e inseri outra discplina
            int idxRecomendacao = Random.Next(disciplinasQueFaltam.Count() - 1);
            int semestre = Random.Next(Value.ToList().Count - 1);
            int index2 = Random.Next(Value[semestre].disciplinasSemestre.Count - 1);
        }
    }
}
