using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Servicos;

namespace ProjetoLivraria.Aplicacao.Classes
{
    public class EditoraAppServico : AppServicoBase<Editora>, IEditoraAppServico
    {
        private readonly IEditoraServico _editoraServico;

        public EditoraAppServico(IEditoraServico editoraServico) : base(editoraServico)
        {
            _editoraServico = editoraServico;
        }
    }
}