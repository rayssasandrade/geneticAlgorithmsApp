using System;
using Accord.Genetic;
using geneticAlgorithmsApp.src.Data;
using geneticAlgorithmsApp.src.Builder;
using geneticAlgorithmsApp.src.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                    .ThenInclude(u => u.Disciplina).ThenInclude(d => d.PreRequisitoDisciplinas).AsNoTracking()
                   .Single();

                var disciplinasRealizadas = usuario.MatriculaDisciplina.Select(dr => dr.Disciplina);

                var disciplinasPendentes = dataContext.Disciplinas.Include(d => d.PreRequisitoDisciplinas).AsNoTrackingWithIdentityResolution().ToList().Except(disciplinasRealizadas, new DisciplinaEqualityComparer());

                usuario.DisciplinasPendentes = disciplinasPendentes.ToList();
                usuario.DisciplinasRealizadas = disciplinasRealizadas;
                Console.WriteLine("Gerando horário para o usuário {0}", usuario.Nome);
                Console.WriteLine("Ele fez {0}/{1}, mas ainda precisa passar em {2} disciplinas", usuario.QtdCreditosAluno, usuario.QtdCreditosPendentes, usuario.DisciplinasPendentes.Count);
                int maxQtdDisciplinasDoSemestre = 8;//usuario.Curso.MaxTempoDia;

                Population population = new Population(5000, new HorarioChromosome(dataContext, usuario, maxQtdDisciplinasDoSemestre), 
                    new FitnessFunction(dataContext), new EliteSelection());
                var preRequisitos = dataContext.PreRequisitoDisciplinas.ToList();
                int i = 0;
                double best = 0;
                int qtdPendentes = usuario.DisciplinasPendentes.ToList().Count();
                double parada = 0.995 + (double)qtdPendentes / 8 / 1000;
                while (true)
                {
                    population.RunEpoch();
                    i++;
                    Console.SetCursorPosition(0, 4);
                    ImprimirEstatistica(population);
                    PlotarHorario(population.BestChromosome, preRequisitos);

                    Console.ReadKey();
                    if (population.FitnessMax > parada || i > 5000) // population.FitnessMax > 0.8 
                    {
                        Console.WriteLine("OBAAAAAAA");
                        Console.WriteLine();
                        var BestChromosome = population.BestChromosome;
                        ImprimirHorario(BestChromosome);
                        PlotarHorario(BestChromosome, preRequisitos);
                        break;
                    }                    
                    else
                    {
                        Console.WriteLine("\n Tentativa {0}- FitnessMax: {1} -- Não deu :(", i, population.FitnessMax);
                        Console.WriteLine("Best = {0}", population.BestChromosome.Fitness.ToString());
                    }
                }
            }
        }

        private static void PlotarHorario(IChromosome bestChromosome, List<PreRequisitoDisciplina> preRequisitos)
        {
            var best = bestChromosome as HorarioChromosome;

            TextCopy.ClipboardService.SetText(best.PlotCode(preRequisitos));
            throw new NotImplementedException("Código do gráfico gerado e copiado para a área de transferência. Use o site https://dreampuf.github.io/GraphvizOnline para visualizar.");
        }

        private static void ImprimirEstatistica(Population population)
        {
            // Console.Clear();
            Console.WriteLine("FitnessMax {0}", population.FitnessMax);
            Console.WriteLine("FitnessAvg {0}", population.FitnessAvg);
            Console.WriteLine("FitnessSum {0}", population.FitnessSum);
            Console.WriteLine("CrossoverRate {0}", population.CrossoverRate);
            Console.WriteLine("population.BestChromosome. {0}", population.BestChromosome.Fitness.ToString());
            //System.Threading.Thread.Sleep(10);
        }

        private static void ImprimirHorario(IChromosome bestChromosome)
        {
            var best = bestChromosome as HorarioChromosome;
            

            Console.WriteLine("Vai realizar o curso com {0} semestres", best.Horarios.Count);
            Console.WriteLine("Pressione para continuar");
            Console.ReadKey();
            var qtd = 0;
            foreach (Semestre s in best.Horarios)
            {
                qtd += ImprimirSemestre(s);
            }
            Console.WriteLine("Total de {0} disciplinas", qtd);

        }

        private static int ImprimirSemestre(Semestre s)
        {

            Console.WriteLine("\n ============ Semestre {0} com {1} Disciplinas ============ ", s.Descricao, s.disciplinasSemestre.Count);
            foreach (Disciplina d in s.disciplinasSemestre)
            {
                Console.WriteLine(" - {0}", d.Nome);
            }
            return s.disciplinasSemestre.Count;
        }

       
    }
}
