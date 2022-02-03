using geneticAlgorithmsApp.src.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;
using geneticAlgorithmsApp.src.Models;

namespace geneticAlgorithmsApp
{
    public static class GraphVizHelper
    {
        //HorarioChromosome horario;
        //public GraphVizHelper(HorarioChromosome horario)
        //{
        //    this.horario = horario;

        //}
        public static string PlotCode(this HorarioChromosome horario, List<PreRequisitoDisciplina> preRequisitos)
        {
            var horarioGerado = string.Join(" ", horario.Horarios.ConvertAll<string>(x => x.PlotCode(horario.Usuario)));
            var disciplinasPendentes = string.Join("\n", horario.Usuario.DisciplinasPendentes.ToList().ConvertAll<string>(d => $"{int.Parse(d.Id)} node [label=\"{d.Nome.Replace(" ", "\n")}\" style=filled,color=red]"));
            var disciplinasOK = string.Join("\n", horario.Usuario.DisciplinasRealizadas.ToList().ConvertAll<string>(d => $"{int.Parse(d.Id)} node [label=\"{d.Nome.Replace(" ", "\n")}\" style=filled,color=green]"));
            return string.Format(@"
digraph{{
 rankdir=LR
    
    {0}
    {1}
    {2}

    start [shape=Mdiamond label=Inicio];
    {3}
    end [shape=Msquare label=Fim];
    {4}
    
}}",
                    disciplinasOK + disciplinasPendentes,
                    string.Join("\n", horario.Horarios.ConvertAll<string>( s => $"start -> {s.disciplinasSemestre.First().Id}")),
                    preRequisitos.PlotCode(),
                    horarioGerado,
                    string.Join("\n", horario.Horarios.ConvertAll<string>(s => $"{s.disciplinasSemestre.Last().Id} -> end"))


            );
        }

        public static string PlotCode(this List<PreRequisitoDisciplina> preRequisitos, bool incluirPontoVirgula = true)
        {
            if (preRequisitos == null) return "";
            return string.Join(" ", preRequisitos.ConvertAll<string>(x => $"\"{x.RequisitoDisciplinaId}\" -> \"{x.DisciplinaId}\";"));
        }

        private static bool corInvertida = true;
        public static string PlotCode(this Semestre semestre, Usuario usuario = null)
        {
            var disciplinas = semestre.disciplinasSemestre.PlotCode(usuario);
            

            var resultado = String.Format(@"
subgraph cluster_{0} {{
  style= filled; 
  color={1}; 
  node [style=filled,color={2}];
  {3}
  label=""{0} Período""}}",
  semestre.Descricao,
  (corInvertida ? "lightgrey" : "white"),
  (corInvertida ? "white" : "lightgrey"),
  disciplinas);
            return resultado;
        }

        public static string PlotCode(this List<Disciplina> disciplinas, Usuario usuario = null, bool GerarPreRequisitos = false)
        {
            
            return String.Join(" -> ", disciplinas.ConvertAll<string>(x => {
                //var fez = usuario != null && usuario.DisciplinasRealizadas.Any(d => d.Nome == x.Nome);
                //var cor = fez ? "green" : "red";
                return $"{x.Id}";
            }));
        }
        public static byte[] PlotAsPng(this HorarioChromosome horario, List<PreRequisitoDisciplina> preRequisitos)
        {
            var plotCode = horario.PlotCode(preRequisitos);
            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);
            return wrapper.GenerateGraph(plotCode, Enums.GraphReturnType.Png);

        }

    }
}
