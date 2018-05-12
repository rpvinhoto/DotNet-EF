using System;
using System.Collections.Generic;
using Wave.Essential.Telas.UserControlBase;

namespace Wave.Essential.Telas
{
    public partial class PrincipalForm : MetroFramework.Forms.MetroForm
    {
        static PrincipalForm _instance;
        static Stack<KeyValuePair<string, string>> _rota;

        public static PrincipalForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PrincipalForm();

                return _instance;
            }
        }

        public static KeyValuePair<string,string> ObterRota()
        {
            return _rota.Pop();
        }

        public static KeyValuePair<string, string> ConsultarRota()
        {
            return _rota.Peek();
        }

        public static void InserirRota(string key, string value)
        {
            _rota.Push(new KeyValuePair<string, string>(key, value));
        }

    public MetroFramework.Controls.MetroPanel PainelPrincipal
        {
            get { return pnPrincipal; }
            set { pnPrincipal = value; }
        }

        public MetroFramework.Controls.MetroLink BotaoVoltar
        {
            get { return lkVoltar; }
            set { lkVoltar = value; }
        }

        public string Titulo
        {
            get { return Text; }
            set { Text = value; }
        }

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            _instance = this;
            _rota = new Stack<KeyValuePair<string, string>>();

            CarregarMenu();
        }

        private void lkVoltar_Click(object sender, EventArgs e)
        {
            if (_rota.Count == 1)
                return;

            var controle = ObterRota();
            pnPrincipal.Controls.RemoveByKey(controle.Key);

            AtualizarTitulo(ConsultarRota().Value);
            Refresh();
        }

        private void CarregarMenu()
        {
            Util.AbrirUserControl(new Menu(), "Menu", "- Wave -");
        }

        private void AtualizarTitulo(string titulo)
        {
            Text = titulo;
        }
    }
}