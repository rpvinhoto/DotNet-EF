using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.MVC.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }

        public virtual IEnumerable<LivroViewModel> Livros { get; set; }
    }
}