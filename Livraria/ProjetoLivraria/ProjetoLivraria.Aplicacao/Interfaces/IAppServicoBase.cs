using System.Collections.Generic;

namespace ProjetoLivraria.Aplicacao.Interfaces
{
    public interface IAppServicoBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);

        TEntidade ObterPorId(int id);

        IEnumerable<TEntidade> ObterTodos();

        void Atualizar(TEntidade entidade);

        void Remover(TEntidade entidade);

        void Dispose();
    }
}