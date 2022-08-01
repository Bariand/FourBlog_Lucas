using FourBlog_Lucas.Areas.Identity.Data;
using FourBlog_Lucas.Models;
using FourBlog_Lucas.Repositories;
using FourBlog_Lucas.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FourBlog.Controllers
{
    public class PostagemController : Controller
    {
        private IPostagemRepository _postagemRepository;
        private ITagRepository _tagRepository;
        private IComentarioRepository _comentarioRepository;
        private UserManager<Usuario> _userManager;
        private FourBlog_Lucas.Areas.Identity.Data.FourBlog_LucasContext _context;

        public PostagemController(FourBlog_Lucas.Areas.Identity.Data.FourBlog_LucasContext context, IPostagemRepository postagemRepository, ITagRepository tagRepository, UserManager<Usuario> userManager, IComentarioRepository comentarioRepository)
        {
            _postagemRepository = postagemRepository;
            _tagRepository = tagRepository;
            _comentarioRepository = comentarioRepository;
            _userManager = userManager;
            _context = context;
        }

        /*
            • localhost:9999/Postagem
                o Nesta página:
                    ▪ Listagem de todas as postagens cadastradas
                    ▪ Campo para filtrar a lista por uma tag especifica
                    ▪ Para cada postagem da lista, um botão para visualiza-la em outra pagina
         */

        public SelectList CarregarTags()
        {
            var tagList = _tagRepository.Listar();
            return new SelectList(tagList, "TagId", "Nome"); //SelectList(lista, valor para enviar, valor para exibir)
        }

        [HttpGet]
        public IActionResult Index(int tagId)
        {
            PostagemViewModel model = new PostagemViewModel();
            model.Tags = CarregarTags();
            
            if (tagId != 0) // "tagId != 0" pois "tagId != null" não é aceita para int
            {
                model.Postagens = _postagemRepository.BuscarPor(tagId);
            }
            else
            {
                model.Postagens = _postagemRepository.Listar();
            }

            return View(model);
        }

        /*
            localhost:9999/Postagem/Cadastrar
        */

        [Authorize]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            PostagemCadastrarViewModel model = new PostagemCadastrarViewModel();
            model.Tags = CarregarTags();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Postagem postagem, int tagId)
        {
            Usuario user = _context.Usuarios.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
            postagem.UsuarioId = user.Id;
            postagem.TagId = tagId;

            _postagemRepository.Cadastrar(postagem);
            _postagemRepository.Salvar();

            TempData["msg"] = "Postagem cadastrada com sucesso!";

            return RedirectToAction("Index");
        }

        /*
            • localhost:9999/Postagem/Visualizar/id?
                o Nesta página:
                    ▪ Toda as informações referentes a postagem em questão (menos o id)
                    ▪ Formulário para cadastrar um comentário a aquela postagem
                    ▪ Listagem de todos os comentários da postagem
            */
        [HttpGet]
        public IActionResult Visualizar(int id)
        {
            PostagemVisualizarViewModel model = new PostagemVisualizarViewModel();
            Postagem postagem = _postagemRepository.BuscarPorId(id);
            model.Postagem = postagem;
            model.Comentarios = _comentarioRepository.Listar();

            return View(model);
        }
    }
}
