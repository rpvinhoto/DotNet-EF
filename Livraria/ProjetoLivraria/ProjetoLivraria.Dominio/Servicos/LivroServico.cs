using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using ProjetoLivraria.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace ProjetoLivraria.Dominio.Servicos
{
    public class LivroServico : ServicoBase<Livro>, ILivroServico
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio) : base(livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return _livroRepositorio.ObterPorTitulo(titulo);
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return _livroRepositorio.ObterTodosOrdenadosPorTitulo();
        }
    }
}
