using AutoMapper;
using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoLivraria.MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppServico _categoriaApp;

        public CategoriasController(ICategoriaAppServico categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        public ActionResult Index()
        {
            var categoriaViewModel = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.ObterTodos());

            return View(categoriaViewModel);
        }

        public ActionResult Details(int id)
        {
            var categoriaEntidade = _categoriaApp.ObterPorId(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoriaEntidade);

            return View(categoriaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaEntidade = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
                _categoriaApp.Adicionar(categoriaEntidade);

                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        public ActionResult Edit(int id)
        {
            var categoriaEntidade = _categoriaApp.ObterPorId(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoriaEntidade);

            return View(categoriaViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaEntidade = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
                _categoriaApp.Atualizar(categoriaEntidade);

                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        public ActionResult Delete(int id)
        {
            var categoriaEntidade = _categoriaApp.ObterPorId(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoriaEntidade);

            return View(categoriaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var categoriaEntidade = _categoriaApp.ObterPorId(id);
            _categoriaApp.Remover(categoriaEntidade);

            return RedirectToAction("Index");
        }
    }
}
