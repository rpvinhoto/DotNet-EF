using ProjetoLivraria.Dominio.Entidades;

namespace ProjetoLivraria.Dominio.Interfaces.Repositorios
{
    public interface ICategoriaRepositorio : IRepositorioBase<Categoria>
    {
        new bool Remover(Categoria categoria);
    }
}