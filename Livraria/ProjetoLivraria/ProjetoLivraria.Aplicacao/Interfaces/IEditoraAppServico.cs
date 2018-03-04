using ProjetoLivraria.Dominio.Entidades;

namespace ProjetoLivraria.Aplicacao.Interfaces
{
    public interface IEditoraAppServico : IAppServicoBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}