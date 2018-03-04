using ProjetoLivraria.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoLivraria.Dominio.Interfaces.Servicos
{
    public interface ILivroServico : IServicoBase<Livro>
    {
        IEnumerable<Livro> ObterPorTitulo(string titulo);
    }
}