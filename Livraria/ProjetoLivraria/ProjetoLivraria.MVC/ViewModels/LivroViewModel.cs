using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.MVC.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public int LivroId { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "Título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Titulo { get; set; }

        [DisplayName("Data da publicação")]
        public DateTime? DataPublicacao { get; set; }

        public int EditoraId { get; set; }

        public virtual EditoraViewModel Editora { get; set; }

        public int CategoriaId { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }
    }
}