using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FourBlog_Lucas.Models;
using Microsoft.AspNetCore.Identity;

namespace FourBlog_Lucas.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Você precisa inserir seu nome para continuar.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Você precisa inserir sua data de nascimento para continuar.")]
    public DateTime DataNascimento { get; set; }

    //Relacionamento 1 : N
    public ICollection<Postagem>? Postagens { get; set; }

    //Relacionamento 1 : N
    public ICollection<Comentario>? Comentarios { get; set; }
}
