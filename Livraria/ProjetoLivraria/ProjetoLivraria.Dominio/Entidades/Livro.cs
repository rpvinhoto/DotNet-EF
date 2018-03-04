using System;

namespace ProjetoLivraria.Dominio.Entidades
{
    public class Livro
    {
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public int EditoraId { get; set; }

        public int CategoriaId { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public virtual Editora Editora { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}