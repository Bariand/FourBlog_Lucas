using FourBlog_Lucas.Models;
using System.Linq.Expressions;

namespace FourBlog_Lucas.Repositories
{
    public interface IPostagemRepository
    {
        public IList<Postagem> Listar();
        //public IList<Postagem> BuscarPor(Expression<Func<Postagem, bool>> filtro);
        public Postagem BuscarPorId(int id);
        public ICollection<Postagem> BuscarPor(int tagId);
        public void Cadastrar(Postagem postagem);
        public void Salvar();
    }
}
