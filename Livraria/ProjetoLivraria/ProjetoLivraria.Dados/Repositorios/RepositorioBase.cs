using ProjetoLivraria.Dados.Contexto;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoLivraria.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected Context Db = new Context();

        public void Adicionar(TEntidade entidade)
        {
            Db.Set<TEntidade>().Add(entidade);
            Db.SaveChanges();
        }

        public void Atualizar(TEntidade entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntidade ObterPorId(int id)
        {
            return Db.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return Db.Set<TEntidade>().ToList();
        }

        public void Remover(TEntidade entidade)
        {
            Db.Set<TEntidade>().Remove(entidade);
            Db.SaveChanges();
        }
    }
}