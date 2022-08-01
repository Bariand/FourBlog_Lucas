using FourBlog_Lucas.Models;

namespace FourBlog_Lucas.Repositories
{
    public interface IComentarioRepository
    {
        public ICollection<Comentario> Listar();
        public void Cadastrar(Comentario comentario);
        public void Salvar();
    }
}
