using System.Collections.Generic;
using System.Linq;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;

namespace ProjetoLivraria.Dados.Repositorios
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {
        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return Db.Livros.Where(l => l.Titulo.Contains(titulo));
        }
    }
}