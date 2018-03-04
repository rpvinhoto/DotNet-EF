using AutoMapper;
using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoLivraria.MVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroAppServico _livroApp;
        private readonly IEditoraAppServico _editoraApp;
        private readonly ICategoriaAppServico _categoriaApp;

        public LivrosController(ILivroAppServico livroApp,
            IEditoraAppServico editoraApp,
            ICategoriaAppServico categoriaApp)
        {
            _livroApp = livroApp;
            _editoraApp = editoraApp;
            _categoriaApp = categoriaApp;
        }

        public ActionResult Index()
        {
            var livroViewModel = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(_livroApp.ObterTodosOrdenadosPorTitulo());

            return View(livroViewModel);
        }

        public ActionResult Details(int id)
        {
            var livroEntidade = _livroApp.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livroEntidade);

            return View(livroViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.EditoraId = new SelectList(_editoraApp.ObterTodos(), "EditoraId", "Nome");
            ViewBag.CategoriaId = new SelectList(_categoriaApp.ObterTodos(), "CategoriaId", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Create(LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                var livroEntidade = Mapper.Map<LivroViewModel, Livro>(livroViewModel);
                _livroApp.Adicionar(livroEntidade);

                return RedirectToAction("Index");
            }

            ViewBag.EditoraId = new SelectList(_editoraApp.ObterTodos(), "EditoraId", "Nome", livroViewModel.EditoraId);
            ViewBag.CategoriaId = new SelectList(_categoriaApp.ObterTodos(), "CategoriaId", "Nome", livroViewModel.CategoriaId);

            return View(livroViewModel);
        }

        public ActionResult Edit(int id)
        {
            var livroEntidade = _livroApp.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livroEntidade);

            ViewBag.EditoraId = new SelectList(_editoraApp.ObterTodos(), "EditoraId", "Nome", livroViewModel.EditoraId);
            ViewBag.CategoriaId = new SelectList(_categoriaApp.ObterTodos(), "CategoriaId", "Nome", livroViewModel.CategoriaId);

            return View(livroViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                var livroEntidade = Mapper.Map<LivroViewModel, Livro>(livroViewModel);
                _livroApp.Atualizar(livroEntidade);

                return RedirectToAction("Index");
            }

            ViewBag.EditoraId = new SelectList(_editoraApp.ObterTodos(), "EditoraId", "Nome", livroViewModel.EditoraId);
            ViewBag.CategoriaId = new SelectList(_categoriaApp.ObterTodos(), "CategoriaId", "Nome", livroViewModel.CategoriaId);

            return View(livroViewModel);
        }

        public ActionResult Delete(int id)
        {
            var livroEntidade = _livroApp.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livroEntidade);

            return View(livroViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var livroEntidade = _livroApp.ObterPorId(id);
            _livroApp.Remover(livroEntidade);

            return RedirectToAction("Index");
        }
    }
}