using FourBlog_Lucas.Models;

namespace FourBlog_Lucas.Repositories
{
    public interface ITagRepository
    {
        public IList<Tag> Listar();
        public void Cadastrar(Tag tag);
        public void Excluir(int id);
        public void Atualizar(Tag tag);
        public void Salvar();
        public Tag BuscarPorId(int id);
    }
}
