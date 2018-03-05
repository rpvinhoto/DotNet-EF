using ProjetoLivraria.Dominio.Entidades;

namespace ProjetoLivraria.Aplicacao.Interfaces
{
    public interface ICategoriaAppServico : IAppServicoBase<Categoria>
    {
        new bool Remover(Categoria categoria);
    }
}