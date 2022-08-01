using FourBlog_Lucas.Models;

namespace FourBlog_Lucas.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private Areas.Identity.Data.FourBlog_LucasContext _context;

        public ComentarioRepository(Areas.Identity.Data.FourBlog_LucasContext context)
        {
            _context = context;
        }
        public ICollection<Comentario> Listar()
        {
            return _context.Comentarios.ToList();
        }
        public void Cadastrar(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
