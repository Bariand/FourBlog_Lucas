using FourBlog_Lucas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FourBlog_Lucas.ViewModels
{
    public class PostagemCadastrarViewModel
    {
        public int PostagemId { get; set; }
        public Postagem Postagem { get; set; }
        public int TagId { get; set; }
        public SelectList Tags { get; set; }
    }
}