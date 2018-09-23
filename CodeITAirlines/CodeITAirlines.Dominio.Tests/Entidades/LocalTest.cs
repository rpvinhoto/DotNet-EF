using CodeItAirlines.Dominio.Entidades;
using CodeItAirlines.Dominio.Enumeradores;
using NUnit.Framework;

namespace CodeITAirlines.Dominio.Tests.Entidades
{
    [TestFixture]
    public class LocalTest
    {
        [Test]
        public void Entrar_uma_pessoa_no_local()
        {
            var local = new Local();
            var pessoa = new Pessoa(1, "Teste", TiposPessoa.Piloto);

            local.Entrar(pessoa);

            Assert.AreEqual(1, local.NumeroDePessoas());
        }

        [Test]
        public void Sair_uma_pessoa_do_local()
        {
            var local = new Local();
            var pessoa1 = new Pessoa(1, "Teste1", TiposPessoa.Piloto);
            var pessoa2 = new Pessoa(2, "Teste2", TiposPessoa.Oficial);
            var pessoa3 = new Pessoa(3, "Teste3", TiposPessoa.Comissaria);

            local.Entrar(pessoa1);
            local.Entrar(pessoa2);
            local.Entrar(pessoa3);
            local.Sair(pessoa1);

            Assert.AreEqual(2, local.NumeroDePessoas());
        }
    }
}