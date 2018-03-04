using ProjetoLivraria.Dominio.Entidades;

namespace ProjetoLivraria.Dominio.Interfaces.Repositorios
{
    public interface IEditoraRepositorio : IRepositorioBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}