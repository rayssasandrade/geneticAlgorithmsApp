using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace geneticAlgorithmsApp.src.Models
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public List<Disciplina> DisciplinasRealizadas { get; set; }

    }
}