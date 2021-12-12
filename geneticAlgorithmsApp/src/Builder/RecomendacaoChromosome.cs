using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using geneticAlgorithmsApp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace geneticAlgorithmsApp.src.Builder
{
    class RecomendacaoChromosome : ChromosomeBase
    {

        private readonly DataContext _dataContext;
        static Random Random = new Random();

        public List<Disciplina> Value;

        public RecomendacaoChromosome(DataContext dataContext)
        {
            _dataContext = dataContext;
            Generate();
        }

        public RecomendacaoChromosome(List<Disciplina> partesRecomendacao, DataContext dataContext)
        {
            _dataContext = dataContext;
            Value = partesRecomendacao.ToList();
        }

        public override void Generate()
        {
            var disciplinaAleatoria = _dataContext.Disciplinas.OrderBy(disciplina => Guid.NewGuid()).FirstOrDefault();
            Value.Add(disciplinaAleatoria);
        }

        public override IChromosome Clone()
        {
            return new RecomendacaoChromosome(Value, _dataContext);
        }

        public override IChromosome CreateNew()
        {
            var recomendacaoChromosome = new RecomendacaoChromosome(_dataContext);
            recomendacaoChromosome.Generate();
            return recomendacaoChromosome;
        }

        public override void Crossover(IChromosome pair)
        {
            var randomVal = Random.Next(0, Value.Count - 2);
            var otherChromsome = pair as RecomendacaoChromosome;
            for (int index = randomVal; index < otherChromsome.Value.Count; index++)
            {
                Value[index] = otherChromsome.Value[index];
            }
        }

        public override void Mutate()
        {
            int index1 = Random.Next(0, _dataContext.Disciplinas.Count());
            int index2 = Random.Next(0, Value.Count - 1);
            var recomendacaoChromosome = _dataContext.Disciplinas.Find(index1);
            Value[index2] = recomendacaoChromosome;
        }

    }
}
