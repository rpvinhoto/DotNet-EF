using CodeItAirlines.Dominio.Entidades;
using CodeItAirlines.Dominio.Enumeradores;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodeITAirlines.Dominio.Tests.Entidades
{
    [TestFixture]
    class CarroTest
    {
        [Test]
        public void Andar_com_carro_vazio()
        {
            var carro = new Carro(2, Locais.Terminal);
            var ex = Assert.Throws<Exception>(() => carro.Andar(Locais.Aviao));

            Assert.AreEqual("Carro está vazio.", ex.Message);
        }

        [Test]
        public void Sair_uma_pessoa_com_carro_vazio()
        {
            var carro = new Carro(2, Locais.Terminal);
            var ex = Assert.Throws<Exception>(() => carro.SairUmaPessoa());

            Assert.AreEqual("Carro está vazio.", ex.Message);
        }

        [Test]
        public void Entrar_no_carro()
        {
            var carro = new Carro(2, Locais.Terminal);
            var pessoa = new Pessoa(1, "Teste1", TiposPessoa.Piloto);

            carro.Entrar(pessoa);

            Assert.AreEqual(1, carro.NumeroDePessoas());
        }

        [Test]
        public void Entrar_varias_pessoas_no_carro()
        {
            var carro = new Carro(2, Locais.Terminal);
            var pessoas = new List<Pessoa>
            {
                new Pessoa(1, "Teste1", TiposPessoa.Piloto),
                new Pessoa(2, "Teste2", TiposPessoa.ChefeDeServicoDeBordo),
                new Pessoa(3, "Teste3", TiposPessoa.Comissaria)
            };

            carro.Entrar(pessoas);

            Assert.AreEqual(3, carro.NumeroDePessoas());
        }

        [Test]
        public void Sair_do_carro()
        {
            var carro = new Carro(2, Locais.Terminal);
            var pessoa = new Pessoa(1, "Teste1", TiposPessoa.Piloto);

            carro.Entrar(pessoa);
            carro.Sair(pessoa);

            Assert.AreEqual(0, carro.NumeroDePessoas());

            carro.Entrar(pessoa);
            carro.SairUmaPessoa();

            Assert.AreEqual(0, carro.NumeroDePessoas());
        }

        [Test]
        public void Andar_com_carro_para_aviao()
        {
            var carro = new Carro(2, Locais.Terminal);
            var pessoa = new Pessoa(1, "Teste1", TiposPessoa.Piloto);

            carro.Entrar(pessoa);
            carro.Andar(Locais.Aviao);

            Assert.AreEqual(Locais.Aviao, carro.LocalidadeAtual);
        }
    }
}