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
            var idUsuario = 88;
            // userFake.DisciplinasRealizadas deve ser carregado aqui tb
            using (var dataContext = new DataContext())
            {
                var usuario = dataContext.Usuarios
                    .Include(u => u.DisciplinasRealizadas)
                    .Single(u =>u.Id== idUsuario);
                Population population = new Population(1000, new HorarioChromosome(dataContext, usuario),
                    new FitnessFunction(dataContext), new EliteSelection());

                int i = 0;
                while (true)
                {
                    population.RunEpoch(); 
                    i++;
                    ImprimirEstatistica(population);
                    if (population.FitnessMax >= 0.99 || i >= 1000)
                    {
                        Console.WriteLine("OBAAAAAAA");
                        Console.WriteLine();
                        ImprimirHorario(population.BestChromosome);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Não deu :(");
                    }
                }

            }


        }

        private static void ImprimirEstatistica(Population population)
        {
            Console.Clear();
            Console.WriteLine("FitnessMax {0}", population.FitnessMax);
            Console.WriteLine("FitnessAvg {0}", population.FitnessAvg);
            Console.WriteLine("CrossoverRate {0}", population.CrossoverRate);
            System.Threading.Thread.Sleep(50);
        }

        private static void ImprimirHorario(IChromosome bestChromosome)
        {
            var best = bestChromosome as HorarioChromosome;

            Console.WriteLine("Vai realizar o curso com {0} semestres", best.Horarios.Count);
            foreach (Semestre s in best.Horarios)
            {
                ImprimirSemestre(s);
            }
        }

        private static void ImprimirSemestre(Semestre s)
        {

            Console.WriteLine("\n ============ Semestre {0} com {1} Disciplinas ============ ", s.Descricao, s.disciplinasSemestre.Count) ;
            foreach (Disciplina d in s.disciplinasSemestre)
            {
                Console.WriteLine(" - {0}", d.Nome);

            }
        }
    }
}
