using System;
using Wave.Essential.Telas.UserControlBase;

namespace Wave.Essential.Telas.Cadastros
{
    public partial class UsuariosUc : ListaBase
    {
        public UsuariosUc()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            Util.AbrirUserControl(new UsuarioUc(1), "UsuarioUc", "Detalhes do usuário");
        }
    }
}
