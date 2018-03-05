using ProjetoLivraria.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoLivraria.Dados.EntidadesConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.Nome).IsRequired();
        }
    }
}