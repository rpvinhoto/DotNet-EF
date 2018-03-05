using AutoMapper;
using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoLivraria.MVC.Controllers
{
    public class EditorasController : Controller
    {
        private readonly IEditoraAppServico _editoraApp;

        public EditorasController(IEditoraAppServico editoraApp)
        {
            _editoraApp = editoraApp;
        }

        public ActionResult Index()
        {
            var editoraViewModel = Mapper.Map<IEnumerable<Editora>, IEnumerable<EditoraViewModel>>(_editoraApp.ObterTodos());

            return View(editoraViewModel);
        }

        public ActionResult Details(int id)
        {
            var editoraEntidade = _editoraApp.ObterPorId(id);
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editoraEntidade);

            return View(editoraViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditoraViewModel editoraViewModel)
        {
            if (ModelState.IsValid)
            {
                var editoraEntidade = Mapper.Map<EditoraViewModel, Editora>(editoraViewModel);
                _editoraApp.Adicionar(editoraEntidade);

                return RedirectToAction("Index");
            }

            return View(editoraViewModel);
        }

        public ActionResult Edit(int id)
        {
            var editoraEntidade = _editoraApp.ObterPorId(id);
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editoraEntidade);

            return View(editoraViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditoraViewModel editoraViewModel)
        {
            if (ModelState.IsValid)
            {
                var editoraEntidade = Mapper.Map<EditoraViewModel, Editora>(editoraViewModel);
                _editoraApp.Atualizar(editoraEntidade);

                return RedirectToAction("Index");
            }

            return View(editoraViewModel);
        }

        public ActionResult Delete(int id)
        {
            var editoraEntidade = _editoraApp.ObterPorId(id);
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editoraEntidade);

            return View(editoraViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditoraViewModel editoraViewModel)
        {
            var editoraEntidade = _editoraApp.ObterPorId(id);
            if (_editoraApp.Remover(editoraEntidade))
                return RedirectToAction("Index");

            return RedirectToAction("Index","Erro", new { msg = "Editora não pode ser excluída pois existe livro vinculado." });
        }
    }
}