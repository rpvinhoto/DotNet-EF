using CodeItAirlines.Dominio.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeItAirlines.Dominio.Entidades
{
    public class Cenario
    {
        private List<Pessoa> _personagens;
        private Local _terminal;
        private Carro _carro;
        private Local _aviao;
        private PoliticaDaEmpresa _politica;

        public void Iniciar()
        {
            CriarPersonagens();
            CriarLocais();
            ColocarPersonagensNoTerminal();
            CriarPolitica();
        }

        private void CriarPersonagens()
        {
            _personagens = new List<Pessoa>
            {
                { new Pessoa(1, "Piloto", TiposPessoa.Piloto, true) },
                { new Pessoa(2, "Oficial 1", TiposPessoa.Oficial) },
                { new Pessoa(3, "Oficial 2", TiposPessoa.Oficial) },
                { new Pessoa(4, "Chefe de serviço", TiposPessoa.ChefeDeServicoDeBordo, true) },
                { new Pessoa(5, "Comissária 1", TiposPessoa.Comissaria) },
                { new Pessoa(6, "Comissária 2", TiposPessoa.Comissaria) },
                { new Pessoa(7, "Policial", TiposPessoa.Policial, true) },
                { new Pessoa(8, "Presidiário", TiposPessoa.Presidiario) }
            };
        }

        private void CriarLocais()
        {
            _terminal = new Local();
            _carro = new Carro(2, Locais.Terminal);
            _aviao = new Local();
        }

        private void CriarPolitica()
        {
            _politica = new PoliticaDaEmpresa();
        }

        private void ColocarPersonagensNoTerminal()
        {
            _terminal.Entrar(_personagens);
        }

        public List<Pessoa> ObterPersonagensNoTerminal()
        {
            return _terminal.Pessoas.Any() ?
                _terminal.Pessoas.OrderBy(p => p.Id).ToList() :
                _terminal.Pessoas;
        }

        public List<Pessoa> ObterPersonagensNoCarro()
        {
            return _carro.Pessoas.Any() ?
                _carro.Pessoas.OrderBy(p => p.Id).ToList() :
                _carro.Pessoas;
        }

        public List<Pessoa> ObterPersonagensNoAviao()
        {
            return _aviao.Pessoas.Any() ?
                _aviao.Pessoas.OrderBy(p => p.Id).ToList() :
                _aviao.Pessoas;
        }

        public void EntrarNoCarro(Pessoa personagem)
        {
            if (_carro.LocalidadeAtual == Locais.Terminal)
                _terminal.Sair(personagem);
            else
                _aviao.Sair(personagem);

            _carro.Entrar(personagem);
        }

        public void SairDoCarro(Pessoa personagem)
        {
            _carro.Sair(personagem);

            if (_carro.LocalidadeAtual == Locais.Terminal)
                _terminal.Entrar(personagem);
            else
                _aviao.Entrar(personagem);
        }

        public Locais ObterLocalidadeAtualDoCarro()
        {
            return _carro.LocalidadeAtual;
        }

        public void Transportar()
        {
            ValidarPoliticasDaEmpresa();

            if (_carro.LocalidadeAtual == Locais.Terminal)
                TransportarDoTerminalParaAviao();
            else
                TransportarDoAviaoParaTerminal();
        }

        private void TransportarDoTerminalParaAviao()
        {
            _carro.Andar(Locais.Aviao);

            while (_carro.Pessoas.Any())
            {
                var pessoa = _carro.SairUmaPessoa();
                _aviao.Entrar(pessoa);
            }
        }

        private void TransportarDoAviaoParaTerminal()
        {
            _carro.Andar(Locais.Terminal);

            while (_carro.Pessoas.Any())
            {
                var pessoa = _carro.SairUmaPessoa();
                _terminal.Entrar(pessoa);
            }
        }

        private void ValidarPoliticasDaEmpresa()
        {
            _politica.ValidarPessoasAcompanhadas(_terminal.Pessoas);

            if (!_politica.Validada)
                throw new Exception(_politica.PoliticaDesrespeitada);

            _politica.ValidarPessoasAcompanhadas(_aviao.Pessoas);

            if (!_politica.Validada)
                throw new Exception(_politica.PoliticaDesrespeitada);

            _politica.ValidarPessoasAcompanhadas(_carro.Pessoas);

            if (!_politica.Validada)
                throw new Exception(_politica.PoliticaDesrespeitada);

            _politica.ValidarPessoaAutorizadaParaDirigir(_carro.Pessoas);

            if (!_politica.Validada)
                throw new Exception(_politica.PoliticaDesrespeitada);
        }
    }
}