using FourBlog_Lucas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FourBlog_Lucas.ViewModels
{
    public class PostagemViewModel
    {
        public ICollection<Postagem> Postagens { get; set; }
        public Postagem Postagem { get; set; }
        public SelectList Tags { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}