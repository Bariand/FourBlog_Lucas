using FourBlog_Lucas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FourBlog_Lucas.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private Areas.Identity.Data.FourBlog_LucasContext _context;

        public PostagemRepository(Areas.Identity.Data.FourBlog_LucasContext context)
        {
            _context = context;
        }

        public IList<Postagem> Listar()
        {
            return _context.Postagens.ToList();
        }

        public Postagem BuscarPorId(int id)
        {
            return _context.Postagens.Include(p => p.Tag).Where(p => p.PostagemId == id).FirstOrDefault(); //Aqui eu consigo pegar o objeto "tag" apenas porque o objeto "postagem" possui sua chave estrangeira
        }
        public ICollection<Postagem> BuscarPor(int tagId)
        {
            return _context.Postagens.Where(p => p.TagId == tagId).ToList();
        }
        public void Cadastrar(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
