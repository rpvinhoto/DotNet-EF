using System.Collections.Generic;

namespace ProjetoLivraria.Dominio.Entidades
{
    public class Editora
    {
        public int EditoraId { get; set; }

        public string Nome { get; set; }

        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}