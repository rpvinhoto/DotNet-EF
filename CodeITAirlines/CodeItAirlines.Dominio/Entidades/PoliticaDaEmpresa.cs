using CodeItAirlines.Dominio.Enumeradores;
using System.Collections.Generic;
using System.Linq;

namespace CodeItAirlines.Dominio.Entidades
{
    public class PoliticaDaEmpresa
    {
        #region Constantes
        private const string OficialComChefeDeServicoDeBordo = "Oficial não pode ficar sozinho com chefe de serviço.";
        private const string ComissariaComPiloto = "Comissária não pode ficar sozinha com piloto.";
        private const string PresidiarioSozinho = "Presidiário não pode ficar sozinho.";
        private const string PresidiarioSemPolicial = "Presidiário não pode ficar sem o policial.";
        private const string CarroSemMotoristaAutorizado = "Nenhuma pessoa no carro está autorizada para dirigir.";
        #endregion

        public bool Validada { get; private set; }

        public string PoliticaDesrespeitada { get; set; }

        public void ValidarPessoasAcompanhadas(List<Pessoa> pessoasNoLocal)
        {
            PoliticaDesrespeitada = string.Empty;
            Validada = true;

            if (!pessoasNoLocal.Any())
                return;

            if (!ValidarOficialSozinhoComChefeDeServicoDeBordo(pessoasNoLocal))
                return;

            if (!ValidarComissariaSozinhaComPiloto(pessoasNoLocal))
                return;

            if (!ValidarPresidiarioSozinho(pessoasNoLocal))
                return;

            ValidarPresidiarioSemPolicial(pessoasNoLocal);
        }

        public bool ValidarPessoaAutorizadaParaDirigir(List<Pessoa> pessoasNoCarro)
        {
            if (!pessoasNoCarro.Exists(p =>
                 p.Tipo == TiposPessoa.Piloto ||
                 p.Tipo == TiposPessoa.ChefeDeServicoDeBordo ||
                 p.Tipo == TiposPessoa.Policial))
            {
                PoliticaDesrespeitada = CarroSemMotoristaAutorizado;
                Validada = false;
            }

            return Validada;
        }

        private bool ValidarOficialSozinhoComChefeDeServicoDeBordo(List<Pessoa> pessoasNoLocal)
        {
            if (pessoasNoLocal.Count == 2 &&
                pessoasNoLocal.Exists(p => p.Tipo == TiposPessoa.Oficial) &&
                pessoasNoLocal.Exists(p => p.Tipo == TiposPessoa.ChefeDeServicoDeBordo))
            {
                PoliticaDesrespeitada = OficialComChefeDeServicoDeBordo;
                Validada = false;
            }

            return Validada;
        }

        private bool ValidarComissariaSozinhaComPiloto(List<Pessoa> pessoasNoLocal)
        {
            if (pessoasNoLocal.Count == 2 &&
                pessoasNoLocal.Exists(p => p.Tipo == TiposPessoa.Comissaria) &&
                pessoasNoLocal.Exists(p => p.Tipo == TiposPessoa.Piloto))
            {
                PoliticaDesrespeitada = ComissariaComPiloto;
                Validada = false;
            }

            return Validada;
        }

        private bool ValidarPresidiarioSozinho(List<Pessoa> pessoasNoLocal)
        {
            if (pessoasNoLocal.Count == 1 &&
                pessoasNoLocal.First().Tipo == TiposPessoa.Presidiario)
            {
                PoliticaDesrespeitada = PresidiarioSozinho;
                Validada = false;
            }

            return Validada;
        }

        private bool ValidarPresidiarioSemPolicial(List<Pessoa> pessoasNoLocal)
        {
            if (pessoasNoLocal.Exists(p => p.Tipo == TiposPessoa.Presidiario) &&
                !pessoasNoLocal.Exists(p => p.Tipo == TiposPessoa.Policial))
            {
                PoliticaDesrespeitada = PresidiarioSemPolicial;
                Validada = false;
            }

            return Validada;
        }
    }
}