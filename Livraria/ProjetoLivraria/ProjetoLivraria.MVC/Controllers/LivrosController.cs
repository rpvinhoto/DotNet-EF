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

        public LivrosController(ILivroAppServico livroApp)
        {
            _livroApp = livroApp;
        }

        public ActionResult Index()


        {
            var livroViewModel = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(_livroApp.ObterTodos());

            return View(livroViewModel);
        }

        public ActionResult Details(int id)
        {
            var livro = _livroApp.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);

            return View(livroViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var livroDominio = Mapper.Map<LivroViewModel, Livro>(livro);
                _livroApp.Adicionar(livroDominio);

                return RedirectToAction("Index");
            }

            return View(livro);
        }

        public ActionResult Edit(int id)
        {
            var livro = _livroApp.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);

            return View(livroViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var livroDominio = Mapper.Map<LivroViewModel, Livro>(livro);
                _livroApp.Atualizar(livroDominio);

                return RedirectToAction("Index");
            }

            return View(livro);
        }

        public ActionResult Delete(int id)
        {
            var livro = _livroApp.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);

            return View(livroViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var livro = _livroApp.ObterPorId(id);
            _livroApp.Remover(livro);

            return RedirectToAction("Index");
        }
    }
}