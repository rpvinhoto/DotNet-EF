using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace ProjetoLivraria.Dados.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public new bool Remover(Categoria categoria)
        {
            if (Db.Livros.ToList().Exists(l => l.CategoriaId == categoria.CategoriaId))
                return false;

            Db.Categorias.Remove(categoria);
            Db.SaveChanges();

            return true;
        }
    }
}