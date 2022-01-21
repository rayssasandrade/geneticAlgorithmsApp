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
        private readonly Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
        }
        private readonly DataContext _dataContext;
        static Random Random = new Random();

        //public List<List<Disciplina>> Value;
        public List<Semestre> Horarios;

        public HorarioChromosome(DataContext dataContext, Usuario usuario, int maxQtdDisciplinasDoSemestre = 18)
        {
            _dataContext = dataContext;
            this._usuario = usuario;
            this.MaxQtdDisciplinasDoSemestre = maxQtdDisciplinasDoSemestre;
            Generate();
        }

        public HorarioChromosome(DataContext dataContext, Usuario usuario, List<Semestre> partesRecomendacao )
        {
            _dataContext = dataContext;
            this._usuario = usuario;
            Horarios = partesRecomendacao.ToList();
        }

        public override void Generate()
        {
            //retirar as displinas que o aluno já fez
            //var meucontexto = _dataContext.Disciplinas.

            //adiciona disciplinas aleatórias em uma quantidade também aleatória por semestre
            //máximo permitido pelo IFS
            //São no máx 15 tempos por dia (15 hr).
            //Levando em consideração que o aluno pode pegar aulas pela manhã, tarde e noite,
            //ele teria 15 * 5 dias. Sabendo que em média temos 4 créditos por disciplina,
            //o aluno pode pegar, no max , 15 * 5 / 4 disciplinas por semestre

            var disciplinasQueFaltam = _dataContext.Disciplinas.Except(Usuario.DisciplinasRealizadas).OrderBy(disciplina => Guid.NewGuid()).AsNoTracking().ToList();
            
            // Se a linha que pega as disciplinas que faltam não funcionar, tente assim:
            // var disciplinas = _dataContext.Disciplinas.OrderBy(disciplina => Guid.NewGuid()).AsNoTracking().ToList();
            // e depois faça a remoção das disciplinas que ele já fez.

            int qtdDisciplinasQueFaltam = disciplinasQueFaltam.Count();
            int qtdSemestre = Random.Next(_dataContext.Disciplinas.ToList().Count);
            for (int i = 1; i <= qtdSemestre; i++)
            {
                int qtdDisciplinasNoSemestre = Random.Next(1, MaxQtdDisciplinasDoSemestre);
                Semestre semestre = new Semestre();
                semestre.Descricao = i.ToString();
                for (int j = 0; j < qtdDisciplinasNoSemestre; j++)
                {
                    var idxDisciplina = Random.Next(qtdDisciplinasQueFaltam);
                    var disciplinaAleatoria = disciplinasQueFaltam[idxDisciplina];
                    semestre.disciplinasSemestre.Add(disciplinaAleatoria);
                }
                Horarios.Add(semestre);
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
            var randomVal = Random.Next(0, Horarios.Count - 2);
            var otherChromsome = pair as HorarioChromosome;
            for (int index = randomVal; index < otherChromsome.Horarios.Count; index++)
            {
                Horarios[index] = otherChromsome.Horarios[index];
            }
        }

        public override void Mutate()
        {
            //alteatoriamente selecionei um semestre, retirei uma disciplina  e inseri outra discplina
            int index1 = Random.Next(0, _dataContext.Disciplinas.Count());
            int semestre = Random.Next(0, Horarios.ToList().Count);
            int index2 = Random.Next(0, _dataContext.Semestres.Find(semestre).disciplinasSemestre.Count);
            var recomendacaoChromosome = _dataContext.Disciplinas.Find(index1);
            Horarios[semestre].disciplinasSemestre[index2] = recomendacaoChromosome;
        }

    }
}
