using System;
using Wave.Essential.Telas.Cadastros;
using Wave.Essential.Telas.UserControlBase;

namespace Wave.Essential.Telas
{
    public partial class Menu : MetroFramework.Controls.MetroUserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void tlUsuarios_Click(object sender, EventArgs e)
        {
            Util.AbrirUserControl(new UsuariosUc(), "UsuariosUc", "Usuários");
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
