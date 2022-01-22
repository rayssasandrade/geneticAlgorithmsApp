using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace geneticAlgorithmsApp.src.Models
{
    public class Disciplina
    {
        public Disciplina()
        {
            PreRequisitoDisciplinas = new List<PreRequisitoDisciplina>();
        }
        public string Id { get; set; }
        public String Nome { get; set; }
        public List<PreRequisitoDisciplina> PreRequisitoDisciplinas { get; set; }
        public List<Turma> Turmas { get; set; }
        public int QtdCreditos { get; set; }
        public int QtdPreRequisitosCreditos { get; set; }
        public int Periodo { get; set; }
        public int AnoPPC { get; set; }
    }
    public class DisciplinaEqualityComparer : IEqualityComparer<Disciplina>
    {
        public bool Equals(Disciplina x, Disciplina y)
        {
            return x.Id.Equals(y.Id);
        }

        int IEqualityComparer<Disciplina>.GetHashCode(Disciplina obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}