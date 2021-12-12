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

        public List<Turma> Value;

        public HorarioChromosome(DataContext dataContext)
        {
            _dataContext = dataContext;
            Generate();
        }

        public HorarioChromosome(List<Turma> partesHorario, DataContext dataContext)
        {
            _dataContext = dataContext;
            Value = partesHorario.ToList();
        }

        static TimeSpan RandomHorarioInicio()
        {
            return TimeSpan.FromMilliseconds(Random.Next((int)TimeSpan.FromHours(9).TotalMilliseconds,
                (int)TimeSpan.FromHours(17).TotalMilliseconds));
        }

        public override void Generate()
        {
            var turmaAleatoria = _dataContext.Turmas.OrderBy(turma => Guid.NewGuid()).FirstOrDefault();
            Value.Add(turmaAleatoria);
        }

        public override IChromosome Clone()
        {
            return new HorarioChromosome(Value, _dataContext);
        }

        public override IChromosome CreateNew()
        {
            var horarioChromosome = new HorarioChromosome(_dataContext);
            horarioChromosome.Generate();
            return horarioChromosome;
        }

        public override void Crossover(IChromosome pair)
        {
            var randomVal = Random.Next(0, Value.Count - 2);
            var otherChromsome = pair as HorarioChromosome;
            for (int index = randomVal; index < otherChromsome.Value.Count; index++)
            {
                Value[index] = otherChromsome.Value[index];
            }
        }

        public override void Mutate()
        {
            var index = Random.Next(0, Value.Count - 1);
            var horarioChromosome = Value.ElementAt(index);
            var qtdHoras = horarioChromosome.HorarioFim.Subtract(horarioChromosome.HorarioInicio);
            horarioChromosome.HorarioInicio = RandomHorarioInicio();
            horarioChromosome.HorarioFim = horarioChromosome.HorarioInicio.Add(qtdHoras);
            horarioChromosome.DiaDaSemana = (DayOfWeek)Random.Next(1, 6);
            Value[index] = horarioChromosome;
        }

    }
}
