using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace ProjetoLivraria.Dados.Repositorios
{
    public class EditoraRepositorio : RepositorioBase<Editora>, IEditoraRepositorio
    {
        public new bool Remover(Editora editora)
        {
            if (Db.Livros.ToList().Exists(l => l.EditoraId == editora.EditoraId))
                return false;

            Db.Editoras.Remove(editora);
            Db.SaveChanges();

            return true;
        }
    }
}