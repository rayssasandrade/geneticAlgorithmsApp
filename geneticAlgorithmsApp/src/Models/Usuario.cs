using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SisGerenciador.src.Models
{
    public class Usuario : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11)]
        [Required(ErrorMessage = "CPF é obrigatório", AllowEmptyStrings = false)]
        public string CPF { get; set; }

        [Display(Name = "Nome")]
        [StringLength(500)]
        [Required(ErrorMessage = "Nome é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "Matricula é obrigatória")]
        public int Matricula { get; set; }
    }
}