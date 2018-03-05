using ProjetoLivraria.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoLivraria.Aplicacao.Interfaces
{
    public interface ILivroAppServico : IAppServicoBase<Livro>
    {
        IEnumerable<Livro> ObterPorTitulo(string titulo);

        IEnumerable<Livro> ObterTodosOrdenadosPorTitulo();
    }
}