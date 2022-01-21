using System;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using geneticAlgorithmsApp.src.Builder;
using geneticAlgorithmsApp.src.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace geneticAlgorithmsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idUsuario = 1;
            // userFake.DisciplinasRealizadas deve ser carregado aqui tb
            using (var dataContext = new DataContext())
            {
                var usuario = dataContext.Usuarios
                    .Include(u => u.DisciplinasRealizadas)
                    .Single(u =>u.Id== idUsuario);
                Population population = new Population(1000, new HorarioChromosome(dataContext, usuario),
                    new FitnessFunction(), new EliteSelection());

                int i = 0;
                while (true)
                {
                    population.RunEpoch(); 
                    i++;
                    if (population.FitnessMax >= 0.99 || i >= 1000)
                    {
                        break;
                    }
                }

            }


        }
    }
}
