using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using Microsoft.EntityFrameworkCore;

namespace geneticAlgorithmsApp.src.Builder
{
    class HorarioChromosome : ChromosomeBase
    {

        private readonly DataContext _dataContext;
        static Random Random = new Random();

        public List<ParteHorarioChromosome> Value;

        public HorarioChromosome(DataContext dataContext)
        {
            _dataContext = dataContext;
            Generate();
        }

        public HorarioChromosome(List<ParteHorarioChromosome> partesHorario, DataContext dataContext)
        {
            _dataContext = dataContext;
            Value = partesHorario.ToList();
        }


        public override void Generate()
        {
            IEnumerable<ParteHorarioChromosome> generateRandomPartes()
            {
                var cursos = _dataContext.Cursos.Include(course => course.Turmas).ToList();

                foreach (var curso in cursos)
                {
                    yield return new ParteHorarioChromosome()
                    {
                        //_dataContext.Turmas
                    };
                }
            }

            Value = generateRandomPartes().ToList();
        }

        public override IChromosome Clone()
        {
            throw new NotImplementedException();
        }

        public override IChromosome CreateNew()
        {
            throw new NotImplementedException();
        }

        public override void Crossover(IChromosome pair)
        {
            throw new NotImplementedException();
        }

        public override void Mutate()
        {
            throw new NotImplementedException();
        }

    }
}
