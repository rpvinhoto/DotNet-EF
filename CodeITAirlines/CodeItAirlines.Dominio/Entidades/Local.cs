using System.Collections.Generic;

namespace CodeItAirlines.Dominio.Entidades
{
    public class Local
    {
        public List<Pessoa> Pessoas { get; private set; }

        public Local()
        {
            Pessoas = new List<Pessoa>();
        }

        public virtual void Entrar(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        public void Entrar(List<Pessoa> pessoas)
        {
            Pessoas.AddRange(pessoas);
        }

        public virtual void Sair(Pessoa pessoa)
        {
            Pessoas.Remove(pessoa);
        }

        public int NumeroDePessoas()
        {
            return Pessoas.Count;
        }
    }
}