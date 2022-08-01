using FourBlog_Lucas.Models;
using System.Linq.Expressions;

namespace FourBlog_Lucas.Repositories
{
    public class TagRepository : ITagRepository
    {
        private Areas.Identity.Data.FourBlog_LucasContext _context;

        public TagRepository(Areas.Identity.Data.FourBlog_LucasContext context)
        {
            _context = context;
        }
        public IList<Tag> Listar()
        {
            return _context.Tags.ToList();
        }
        public void Cadastrar(Tag tag)
        {
            _context.Tags.Add(tag);
        }
        public void Excluir(int id)
        {
            Tag tag = _context.Tags.Find(id);
            _context.Tags.Remove(tag);
        }
        public void Atualizar(Tag tag)
        {
            _context.Tags.Update(tag);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }
        public Tag BuscarPorId(int id)
        {
            return _context.Tags.Where(a => a.TagId == id).FirstOrDefault();
        }
        public IList<Tag> BuscarPor(Expression<Func<Tag, bool>> filtro)
        {
            return _context.Tags.Where(filtro).OrderBy(p => p.Nome).ToList();
        }
    }
}
