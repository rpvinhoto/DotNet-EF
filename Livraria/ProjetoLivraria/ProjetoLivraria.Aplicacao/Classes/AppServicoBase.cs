using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoLivraria.Aplicacao.Classes
{
    public class AppServicoBase<TEntidade> : IDisposable, IAppServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IServicoBase<TEntidade> _servicoBase;

        public AppServicoBase(IServicoBase<TEntidade> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(TEntidade entidade)
        {
            _servicoBase.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }

        public TEntidade ObterPorId(int id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _servicoBase.Remover(entidade);
        }
    }
}