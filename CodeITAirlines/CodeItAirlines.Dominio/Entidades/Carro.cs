using CodeItAirlines.Dominio.Enumeradores;
using System;
using System.Linq;

namespace CodeItAirlines.Dominio.Entidades
{
    public class Carro : Local
    {
        #region Constantes
        private const string CarroLotado = "Carro está lotado.";
        private const string CarroVazio = "Carro está vazio.";
        #endregion

        public Locais LocalidadeAtual { get; private set; }

        private readonly int _capacidade;

        public Carro(int capacidade, Locais localidadeAtual)
        {
            _capacidade = capacidade;
            LocalidadeAtual = localidadeAtual;
        }

        public void Andar(Locais destino)
        {
            if (CarroEstaVazio())
                throw new Exception(CarroVazio);

            LocalidadeAtual = destino;
        }

        public override void Entrar(Pessoa pessoa)
        {
            if (CarroEstaLotado())
                throw new Exception(CarroLotado);

            base.Entrar(pessoa);
        }

        public override void Sair(Pessoa pessoa)
        {
            if (CarroEstaVazio())
                throw new Exception(CarroVazio);

            base.Sair(pessoa);
        }

        public Pessoa SairUmaPessoa()
        {
            if (CarroEstaVazio())
                throw new Exception(CarroVazio);

            var pessoa = Pessoas.First();

            Sair(pessoa);

            return pessoa;
        }

        private bool CarroEstaVazio()
        {
            return NumeroDePessoas() == 0;
        }

        private bool CarroEstaLotado()
        {
            return NumeroDePessoas() == _capacidade;
        }
    }
}