using ProjetoLivraria.Dominio.Entidades;

namespace ProjetoLivraria.Dominio.Interfaces.Servicos
{
    public interface ICategoriaServico : IServicoBase<Categoria>
    {
        new bool Remover(Categoria categoria);
    }
}