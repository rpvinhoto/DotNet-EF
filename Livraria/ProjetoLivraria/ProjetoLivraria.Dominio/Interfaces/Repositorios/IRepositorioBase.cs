using System.Collections.Generic;

namespace ProjetoLivraria.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);

        TEntidade ObterPorId(int id);

        IEnumerable<TEntidade> ObterTodos();

        void Atualizar(TEntidade entidade);

        void Remover(TEntidade entidade);

        void Dispose();
    }
}