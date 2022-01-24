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
                var usuario = dataContext.Usuarios.Where(u => u.Id == idUsuario)
                    .Include(u => u.MatriculaDisciplina)
                    .ThenInclude(u => u.Disciplina).AsNoTracking()
                   .Single();

                var disciplinasRealizadas = usuario.MatriculaDisciplina.Select(dr => dr.Disciplina);

                var disciplinasPendentes = dataContext.Disciplinas.AsNoTrackingWithIdentityResolution().ToList().Except(disciplinasRealizadas, new DisciplinaEqualityComparer());

//                var disciplinasQueFaltam = dataContext.Disciplinas.Include(d => d.PreRequisitoDisciplinas).AsNoTracking().ToList().Except(usuario.DisciplinasRealizadas, new DisciplinaEqualityComparer());
                usuario.DisciplinasPendentes = disciplinasPendentes.ToList();
                usuario.DisciplinasRealizadas = disciplinasRealizadas;
                Console.WriteLine("Gerando horário para o usuário {0}", usuario.Nome);
                Console.WriteLine("Ele fez {0}/{1}, mas ainda precisa passar em {2} disciplinas", usuario.QtdCreditosAluno, usuario.QtdCreditosPendentes, usuario.DisciplinasPendentes.Count);


                Population population = new Population(2000, new HorarioChromosome(dataContext, usuario),
                    new FitnessFunction(dataContext), new EliteSelection());

                int i = 0;
                double best = 0;
                while (true)
                {
                    population.RunEpoch(); 
                    i++;
                    Console.SetCursorPosition(0, 4);
                    best = Math.Max(best, population.FitnessMax);
                    ImprimirEstatistica(population);

                    if (population.FitnessMax >= 0.70 || i >= 3000)
                    {

                        Console.WriteLine("OBAAAAAAA");
                        Console.WriteLine();
                        ImprimirHorario(population.BestChromosome);
                        break;
                    }                    
                    else
                    {

                        Console.WriteLine("\n Tentativa {0}- FitnessMax: {1} -- Não deu :(", i, population.FitnessMax);
                        Console.WriteLine("Best = {0}", best);
                    }
                }

            }


        }

        private static void ImprimirEstatistica(Population population)
        {
            // Console.Clear();
            Console.WriteLine("FitnessMax {0}", population.FitnessMax);
            Console.WriteLine("FitnessAvg {0}", population.FitnessAvg);
            Console.WriteLine("CrossoverRate {0}", population.CrossoverRate);
            //System.Threading.Thread.Sleep(10);
        }

        private static void ImprimirHorario(IChromosome bestChromosome)
        {
            var best = bestChromosome as HorarioChromosome;

            Console.WriteLine("Vai realizar o curso com {0} semestres", best.Horarios.Count);
            Console.WriteLine("Pressione para continuar");
            Console.ReadKey();
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
