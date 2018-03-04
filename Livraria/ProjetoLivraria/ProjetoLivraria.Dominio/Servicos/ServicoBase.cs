using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using ProjetoLivraria.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoLivraria.Dominio.Servicos
{
    public class ServicoBase<TEntidade> : IDisposable, IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> _repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(TEntidade entidade)
        {
            _repositorio.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public TEntidade ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _repositorio.Remover(entidade);
        }
    }
}
