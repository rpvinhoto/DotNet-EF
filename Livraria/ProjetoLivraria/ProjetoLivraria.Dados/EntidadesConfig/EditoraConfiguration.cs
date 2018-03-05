using ProjetoLivraria.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoLivraria.Dados.EntidadesConfig
{
    public class EditoraConfiguration : EntityTypeConfiguration<Editora>
    {
        public EditoraConfiguration()
        {
            HasKey(e => e.EditoraId);

            Property(e => e.Nome).IsRequired();

        }
    }
}