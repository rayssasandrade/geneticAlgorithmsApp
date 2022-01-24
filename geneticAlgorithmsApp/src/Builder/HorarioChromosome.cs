﻿using System;
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
        public List<Semestre> Horarios = new List<Semestre>();

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
            //var usuario = _dataContext.Usuarios.FirstOrDefault(p => p.UserName == Usuario.IdentityUser.Name);

            //adiciona disciplinas aleatórias em uma quantidade também aleatória por semestre
            //máximo permitido pelo IFS
            //São no máx 15 tempos por dia (15 hr).
            //Levando em consideração que o aluno pode pegar aulas pela manhã, tarde e noite,
            //ele teria 15 * 5 dias. Sabendo que em média temos 4 créditos por disciplina,
            //o aluno pode pegar, no max , 15 * 5 / 4 disciplinas por semestre

            var disciplinasQueFaltam = _dataContext.Disciplinas.Include(d => d.PreRequisitoDisciplinas).ToList().Except(Usuario.DisciplinasRealizadas, new DisciplinaEqualityComparer()).OrderBy(disciplina => Guid.NewGuid()).ToList();

            // Se a linha que pega as disciplinas que faltam não funcionar, tente assim:
            // var disciplinas = _dataContext.Disciplinas.OrderBy(disciplina => Guid.NewGuid()).AsNoTracking().ToList();
            // e depois faça a remoção das disciplinas que ele já fez.

            int qtdDisciplinasQueFaltam = disciplinasQueFaltam.Count();
            //int qtdSemestre = Random.Next(1, Math.Min(qtdDisciplinasQueFaltam, MaxQtdDisciplinasDoSemestre) );
            int qtdSemestre = Random.Next(1, qtdDisciplinasQueFaltam);
            for (int i = 1; i <= qtdSemestre; i++)
            {
                int qtdDisciplinasNoSemestre = Random.Next(1, Math.Min(qtdDisciplinasQueFaltam, MaxQtdDisciplinasDoSemestre));
                Semestre semestre = new Semestre();
                semestre.Descricao = i.ToString();
                for (int j = 0; j < qtdDisciplinasNoSemestre; j++)
                {
                    var idxDisciplina = Random.Next(1, qtdDisciplinasQueFaltam);
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
    //Horario    XXXXX XXXXX

    //other      YYYYY YY

    //H  Novo    XXXXX YYXXX
        public override void Crossover(IChromosome pair)
        {
            var otherChromsome = pair as HorarioChromosome;
            int qtdMin = Math.Min(Horarios.Count, otherChromsome.Horarios.Count);
            var randomVal = Random.Next(qtdMin);
            for (int index = randomVal; index < qtdMin; index++)
            {
                Horarios[index] = otherChromsome.Horarios[index];
            }
        }

        public override void Mutate()
        {
            var disciplinasQueFaltam = _dataContext.Disciplinas.Include(d => d.PreRequisitoDisciplinas).ToList().Except(Usuario.DisciplinasRealizadas, new DisciplinaEqualityComparer()).OrderBy(disciplina => Guid.NewGuid()).ToList();
            //alteatoriamente selecionei um semestre, retirei uma disciplina  e inseri outra discplina
            int idxRecomendacao = Random.Next(disciplinasQueFaltam.Count()-1);
            int semestre = Random.Next(Horarios.ToList().Count-1);
            int index2 = Random.Next(Horarios[semestre].disciplinasSemestre.Count-1);

            var recomendacaoChromosome = disciplinasQueFaltam[idxRecomendacao];
            Horarios[semestre].disciplinasSemestre[index2] = recomendacaoChromosome;
        }

    }
}
