using CodeItAirlines.Dominio.Entidades;
using CodeItAirlines.Dominio.Enumeradores;
using NUnit.Framework;
using System;
using System.Linq;

namespace CodeITAirlines.Dominio.Tests.Entidades
{
    [TestFixture]
    class CenarioTest
    {
        private Cenario _cenario;

        [SetUp]
        public void SetUp()
        {
            _cenario = new Cenario();
        }

        [Test]
        public void Iniciar_cenario_padrao()
        {
            _cenario.Iniciar();

            var personagensNoTerminal = _cenario.ObterPersonagensNoTerminal();
            var personagensNoCarro = _cenario.ObterPersonagensNoCarro();
            var personagensNoAviao = _cenario.ObterPersonagensNoAviao();

            Assert.AreEqual(8, personagensNoTerminal.Count);
            Assert.AreEqual(0, personagensNoCarro.Count);
            Assert.AreEqual(0, personagensNoAviao.Count);
            Assert.AreEqual(Locais.Terminal, _cenario.ObterLocalidadeAtualDoCarro());
        }

        [Test]
        public void Andar_com_carro_vazio()
        {
            var carro = new Carro(2, Locais.Terminal);
            var ex = Assert.Throws<Exception>(() => carro.Andar(Locais.Aviao));

            Assert.AreEqual("Carro está vazio.", ex.Message);
        }

        [Test]
        public void Entrar_pessoa_com_carro_lotado()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First());
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First());

            var ex = Assert.Throws<Exception>(() => _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First()));

            Assert.AreEqual("Carro está lotado.", ex.Message);
        }

        [TestCase(TiposPessoa.Comissaria)]
        [TestCase(TiposPessoa.Oficial)]
        public void Andar_com_carro_sem_pessoa_autorizada(TiposPessoa tipo)
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == tipo));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Nenhuma pessoa no carro está autorizada para dirigir.", ex.Message);
        }

        [TestCase(TiposPessoa.Comissaria, TiposPessoa.Comissaria)]
        [TestCase(TiposPessoa.Comissaria, TiposPessoa.Oficial)]
        [TestCase(TiposPessoa.Oficial, TiposPessoa.Oficial)]
        public void Andar_com_carro_sem_pessoa_autorizada(TiposPessoa tipo1, TiposPessoa tipo2)
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == tipo1));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == tipo2));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Nenhuma pessoa no carro está autorizada para dirigir.", ex.Message);
        }

        [TestCase(TiposPessoa.Piloto)]
        [TestCase(TiposPessoa.ChefeDeServicoDeBordo)]
        public void Andar_com_carro_com_pessoa_autorizada(TiposPessoa tipo)
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == tipo));
            _cenario.Transportar();

            var personagensNoTerminal = _cenario.ObterPersonagensNoTerminal();
            var personagensNoCarro = _cenario.ObterPersonagensNoCarro();
            var personagensNoAviao = _cenario.ObterPersonagensNoAviao();

            Assert.AreEqual(7, personagensNoTerminal.Count);
            Assert.AreEqual(0, personagensNoCarro.Count);
            Assert.AreEqual(1, personagensNoAviao.Count);
            Assert.AreEqual(Locais.Aviao, _cenario.ObterLocalidadeAtualDoCarro());
        }

        [TestCase(TiposPessoa.Piloto, TiposPessoa.ChefeDeServicoDeBordo)]
        [TestCase(TiposPessoa.Piloto, TiposPessoa.Oficial)]
        [TestCase(TiposPessoa.ChefeDeServicoDeBordo, TiposPessoa.Comissaria)]
        [TestCase(TiposPessoa.Policial, TiposPessoa.Presidiario)]
        public void Andar_com_carro_com_pessoa_autorizada(TiposPessoa tipo1, TiposPessoa tipo2)
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == tipo1));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == tipo2));
            _cenario.Transportar();

            var personagensNoTerminal = _cenario.ObterPersonagensNoTerminal();
            var personagensNoCarro = _cenario.ObterPersonagensNoCarro();
            var personagensNoAviao = _cenario.ObterPersonagensNoAviao();

            Assert.AreEqual(6, personagensNoTerminal.Count);
            Assert.AreEqual(0, personagensNoCarro.Count);
            Assert.AreEqual(2, personagensNoAviao.Count);
            Assert.AreEqual(Locais.Aviao, _cenario.ObterLocalidadeAtualDoCarro());
        }

        [Test]
        public void Deixar_presidiario_sozinho_no_aviao()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Policial));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Presidiario));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Policial));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Presidiário não pode ficar sozinho.", ex.Message);
        }

        [Test]
        public void Deixar_presidiario_sozinho_no_terminal()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Oficial));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Comissaria));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Comissaria));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Oficial));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Policial));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Presidiário não pode ficar sozinho.", ex.Message);
        }

        [Test]
        public void Deixar_presidiario_no_terminal_sem_policial()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Policial));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Presidiário não pode ficar sem o policial.", ex.Message);
        }

        [Test]
        public void Deixar_presidiario_no_carro_sem_policial()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Presidiario));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Presidiário não pode ficar sem o policial.", ex.Message);
        }

        [Test]
        public void Deixar_presidiario_no_aviao_sem_policial()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Policial));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Presidiario));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Policial));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Presidiário não pode ficar sem o policial.", ex.Message);
        }

        [Test]
        public void Deixar_oficial_sozinho_com_chefe_de_servico_no_carro()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Oficial));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Oficial não pode ficar sozinho com chefe de serviço.", ex.Message);
        }

        [Test]
        public void Deixar_oficial_sozinho_com_chefe_de_servico_no_aviao()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Oficial));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.Piloto));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Oficial não pode ficar sozinho com chefe de serviço.", ex.Message);
        }

        [Test]
        public void Deixar_comissaria_sozinha_com_piloto_no_carro()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Comissaria));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Comissária não pode ficar sozinha com piloto.", ex.Message);
        }

        [Test]
        public void Deixar_comissaria_sozinha_com_piloto_no_aviao()
        {
            _cenario.Iniciar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Piloto));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoTerminal().First(p => p.Tipo == TiposPessoa.Comissaria));
            _cenario.Transportar();
            _cenario.EntrarNoCarro(_cenario.ObterPersonagensNoAviao().First(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo));

            var ex = Assert.Throws<Exception>(() => _cenario.Transportar());

            Assert.AreEqual("Comissária não pode ficar sozinha com piloto.", ex.Message);
        }
    }
}