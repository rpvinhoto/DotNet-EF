using ProjetoLivraria.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoLivraria.Dados.EntidadesConfig
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            HasKey(l => l.LivroId);

            Property(l => l.Titulo).IsRequired();

            HasRequired(l => l.Editora).WithMany().HasForeignKey(l => l.EditoraId);
            HasRequired(l => l.Categoria).WithMany().HasForeignKey(l => l.CategoriaId);
        }
    }
}