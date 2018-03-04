using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace ProjetoLivraria.Aplicacao.Classes
{
    public class LivroAppServico : AppServicoBase<Livro>, ILivroAppServico
    {
        private readonly ILivroServico _livroServico;

        public LivroAppServico(ILivroServico livroServico) : base(livroServico)
        {
            _livroServico = livroServico;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return _livroServico.ObterPorTitulo(titulo);
        }
    }
}