using FourBlog_Lucas.Models;
using FourBlog_Lucas.Repositories;
using FourBlog_Lucas.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FourBlog_Lucas.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        /*
         • localhost:9999/Tag
             o Nesta página:
                 ▪ Formulário para criar uma nova tag
                 ▪ Listagem de todas as tags com botões para a página de editar uma em especifico
         */
        private ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult index()
        {
            TagViewModel viewModel = new TagViewModel();

            viewModel.Tags = _tagRepository.Listar();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Criar(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Cadastrar(tag);
                _tagRepository.Salvar();

                TempData["TagCadastrada"] = "Tag cadastrada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["TagNaoCadastrada"] = "Uma Tag precisa de um nome para ser cadastrada!";

            return RedirectToAction("Index");
        }

        /*
         • localhost:9999/Tag/Editar/id?
            o Nesta página:
                ▪ Formulário com as informações da tarefa em questão para poder editar
                ▪ Botão para enviar o formulário com as novas informações para a funcionalidade de editar
                ▪ Botão para remover a tag em questão, com confirmação no modal
         */
        [HttpGet]
        public IActionResult Editar(int id)
        {
            Tag tag = _tagRepository.BuscarPorId(id);

            return View(tag);
        }
        [HttpPost]
        public IActionResult Editar(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Atualizar(tag);
                _tagRepository.Salvar();

                TempData["TagEditada"] = "Tag editada com sucesso!";

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _tagRepository.Excluir(id);
            _tagRepository.Salvar();

            TempData["TagExcluida"] = "Você excluiu a tag com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
