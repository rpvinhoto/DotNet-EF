using ProjetoLivraria.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoLivraria.Dominio.Interfaces.Repositorios
{
    public interface ILivroRepositorio : IRepositorioBase<Livro>
    {
        IEnumerable<Livro> ObterPorTitulo(string titulo);

        IEnumerable<Livro> ObterTodosOrdenadosPorTitulo();
    }
}