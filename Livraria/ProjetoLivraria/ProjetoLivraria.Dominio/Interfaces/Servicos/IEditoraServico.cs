using ProjetoLivraria.Dominio.Entidades;

namespace ProjetoLivraria.Dominio.Interfaces.Servicos
{
    public interface IEditoraServico : IServicoBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}