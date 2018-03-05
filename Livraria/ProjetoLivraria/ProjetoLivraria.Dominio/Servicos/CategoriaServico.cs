using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using ProjetoLivraria.Dominio.Interfaces.Servicos;

namespace ProjetoLivraria.Dominio.Servicos
{
    public class CategoriaServico : ServicoBase<Categoria>, ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio) : base(categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public new bool Remover(Categoria categoria)
        {
            return _categoriaRepositorio.Remover(categoria);
        }
    }
}