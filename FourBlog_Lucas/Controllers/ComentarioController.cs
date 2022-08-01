using FourBlog_Lucas.Areas.Identity.Data;
using FourBlog_Lucas.Models;
using FourBlog_Lucas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FourBlog_Lucas.Controllers
{
    public class ComentarioController : Controller
    {
        private IComentarioRepository _comentarioRepository;
        private UserManager<Usuario> _userManager;
        private FourBlog_Lucas.Areas.Identity.Data.FourBlog_LucasContext _context;

        public ComentarioController(IComentarioRepository comentarioRepository, UserManager<Usuario> userManager, FourBlog_LucasContext context)
        {
            _comentarioRepository = comentarioRepository;
            _userManager = userManager;
            _context = context;
        }

        /*
         Comentários devem ser criados e listados na página de Postagem que contém estes comentários. Deve-se usar uma Viewmodel.
         */

        [Authorize]
        [HttpPost]
        public IActionResult Criar(Comentario comentario, int postagemId)
        {
            Usuario user = _context.Usuarios.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
            comentario.PostagemId = postagemId;
            comentario.UsuarioId = _userManager.GetUserId(User);
            int id = postagemId;

            if (ModelState.IsValid)
            {
                _comentarioRepository.Cadastrar(comentario);
                _comentarioRepository.Salvar();
                
                TempData["msg"] = "Tag cadastrada com sucesso!";

                return RedirectToAction("Visualizar", "Postagem", new { id });
            }

            return RedirectToAction("Visualizar", "Postagem", new { id });
        }
    }
}