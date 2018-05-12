using HarlemErpBusiness;
using HarlemErpDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HarlemERP.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        #region Events
        public event EventHandler LoggedOn;
        public event EventHandler CloseButtonClick;
        #endregion

        #region Constructors
        public LoginView()
        {
            InitializeComponent();

#if DEBUG
            tbLogin.Text = "admin";
            pbSenha.Password = "forrestgump";
#endif
        }
        #endregion

        #region Methods
        public void OnLoggedOn(EventArgs e)
        {
            if (LoggedOn != null)
                LoggedOn(this, e);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login(tbLogin.Text, pbSenha.Password);
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            if (CloseButtonClick != null)
                CloseButtonClick(this, e);
        }

        private void pbSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbErroLogin.Text))
            {
                tbErroLogin.Visibility = Visibility.Hidden;
                tbErroLogin.Text = string.Empty;
            }

            if (e.Key == Key.Enter)
                Login(tbLogin.Text, pbSenha.Password);
        }

        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                pbSenha.Focus();
        }

        private void Login(string username, string password)
        {
            using (var entidades = new DataModelEntities())
            {
                var encryptedPassword = Crypto.GenerateMD5Hash(password);
                var usuario = entidades.usuarios.Where(p => p.login == username && p.senha == encryptedPassword).FirstOrDefault();
                if (usuario == null)
                {
                    tbErroLogin.Visibility = Visibility.Visible;
                    tbErroLogin.Text = "Usuário ou senha incorreta.";

                    pbSenha.Focus();
                }
                else
                {
                    tbLogin.Text = string.Empty;
                    pbSenha.Password = string.Empty;

                    AppContext.UsuarioLogado = usuario;
                    OnLoggedOn(new EventArgs());
                }
            }
        }
        #endregion
    }
}
