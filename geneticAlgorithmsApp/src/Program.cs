using System;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using geneticAlgorithmsApp.src.Builder;
using geneticAlgorithmsApp.src.Models;

namespace geneticAlgorithmsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dataContext = new DataContext())
            {
                Population population = new Population(1000, new HorarioChromosome(dataContext),
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
