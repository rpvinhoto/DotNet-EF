using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Servicos;

namespace ProjetoLivraria.Aplicacao.Classes
{
    public class CategoriaAppServico : AppServicoBase<Categoria>, ICategoriaAppServico
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaAppServico(ICategoriaServico categoriaServico) : base(categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        public new bool Remover(Categoria categoria)
        {
            return _categoriaServico.Remover(categoria);
        }
    }
}
