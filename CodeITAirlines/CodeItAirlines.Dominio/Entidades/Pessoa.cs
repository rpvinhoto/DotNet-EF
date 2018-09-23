using CodeItAirlines.Dominio.Enumeradores;

namespace CodeItAirlines.Dominio.Entidades
{
    public class Pessoa
    {
        public int Id { get; private set; }

        public string Descricao { get; private set; }

        public TiposPessoa Tipo { get; private set; }

        public bool AutorizadoParaDirigirCarro { get; set; }

        public Pessoa(int _id, string descricao, TiposPessoa tipo, bool autorizado = false)
        {
            Id = _id;
            Descricao = descricao;
            Tipo = tipo;
            AutorizadoParaDirigirCarro = autorizado;
        }
    }
}