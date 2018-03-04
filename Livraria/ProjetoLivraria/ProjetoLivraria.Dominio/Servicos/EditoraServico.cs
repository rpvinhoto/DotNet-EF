using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using ProjetoLivraria.Dominio.Interfaces.Servicos;

namespace ProjetoLivraria.Dominio.Servicos
{
    public class EditoraServico : ServicoBase<Editora>, IEditoraServico
    {
        private readonly IEditoraRepositorio _editoraRepositorio;

        public EditoraServico(IEditoraRepositorio editoraRepositorio) : base(editoraRepositorio)
        {
            _editoraRepositorio = editoraRepositorio;
        }
    }
}