using HarlemErpDataModel;
using System;

namespace HarlemERP
{
    public static class AppContext
    {
        private static usuarios _usuarioLogado;

        public static usuarios UsuarioLogado
        {
            get { return _usuarioLogado; }
            set
            {
                LogonDateTime = DateTime.Now;
                _usuarioLogado = value;
            }
        }

        public static bool Logado
        {
            get { return UsuarioLogado != null; }
        }

        public static DateTime LogonDateTime { get; set; }

        public static void Logoff()
        {
            UsuarioLogado = null;
        }
    }
}
