using ProjetoLivraria.Dados.EntidadesConfig;
using ProjetoLivraria.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoLivraria.Dados.Contexto
{
    public class Context : DbContext
    {
        public Context()
            : base("ProjetoLivraria")

        {

        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Editora> Editoras { get; set; }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == string.Format("{0}Id", p.ReflectedType.Name)).Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new LivroConfiguration());
            modelBuilder.Configurations.Add(new EditoraConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
        }
    }
}