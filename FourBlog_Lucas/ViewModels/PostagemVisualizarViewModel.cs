using FourBlog_Lucas.Models;
using System.Collections;

namespace FourBlog_Lucas.ViewModels
{
    public class PostagemVisualizarViewModel
    {
        public Postagem Postagem { get; set; }
        public int PostagemId { get; set; }
        public Comentario Comentario { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
