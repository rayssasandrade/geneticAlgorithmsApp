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

        private readonly DataContext _dataContext;
        static Random Random = new Random();

        //public List<List<Disciplina>> Value;
        public List<Semestre> Horarios;

        public HorarioChromosome(DataContext dataContext)
        {
            _dataContext = dataContext;
            Generate();
        }

        public HorarioChromosome(List<Semestre> partesRecomendacao, DataContext dataContext)
        {
            _dataContext = dataContext;
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

            int qtdSemestre = Random.Next(0,_dataContext.Disciplinas.ToList().Count);
            for (int i = 1; i <= qtdSemestre; i++)
            {
                int qtdDisciplinasNoSemestre = Random.Next(1, 18);
                Semestre semestre = new Semestre();
                semestre.Descricao = "" + i;
                for (int j = 0; j < qtdDisciplinasNoSemestre; j++)
                {
                    var disciplinaAleatoria = _dataContext.Disciplinas.OrderBy(disciplina => Guid.NewGuid()).FirstOrDefault();
                    semestre.disciplinasSemestre.Add(disciplinaAleatoria);
                }
                Horarios.Add(semestre);
            }
        }

        public override IChromosome Clone()
        {
            return new HorarioChromosome(Horarios, _dataContext);
        }

        public override IChromosome CreateNew()
        {
            var recomendacaoChromosome = new HorarioChromosome(_dataContext);
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
