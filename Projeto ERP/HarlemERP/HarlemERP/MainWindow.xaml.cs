using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using HarlemErpDataModel;
using HarlemErpBusiness;
using HarlemERP;
using MahApps.Metro;
using HarlemERP.Views;
using HarlemErpClient.Views;

namespace HarlemErpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            InitializeVariables();
        }
        #endregion

        #region Methods
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (!AppContext.Logado)
                ShowLoginView();
        }

        private void InitializeVariables()
        {
            //Trocar Accent Colors
            //var theme = ThemeManager.DetectAppStyle(Application.Current);
            //var accent = ThemeManager.GetAccent("Red");
            //ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);

            //Trocar tema base
            //var themeColor = ThemeManager.DetectAppStyle(Application.Current);
            //var appTheme = ThemeManager.GetAppTheme("BaseDark"); //BaseLight
            //ThemeManager.ChangeAppStyle(Application.Current, themeColor.Item2, appTheme);

            GSystemView.Visibility = Visibility.Hidden;
            GLoginView.Visibility = Visibility.Visible;
        }

        private void ShowLoginView()
        {
            GLoginView.Visibility = Visibility.Visible;
            var loginView = new LoginView();

            loginView.CloseButtonClick += (s, e) =>
                {
                    AppContext.Logoff();
                    GC.Collect();
                    this.Close();
                };
            loginView.LoggedOn += (s, e) =>
                {
                    tbUsuarioLogado.Text = AppContext.UsuarioLogado.nome;
                    tbContratante.Text = "World Gym Suplementos";
                    GSystemView.Visibility = Visibility.Visible;
                    GLoginView.Visibility = Visibility.Hidden;
                    MCLoginView.Content = null;
                    MCLoginView.UpdateLayout();
                    loginView = null;
                };

            MCLoginView.Content = loginView;
            MCLoginView.UpdateLayout();
#if DEBUG
            ((LoginView)MCLoginView.Content).pbSenha.Focus();
#else
            ((LoginView)MCLoginView.Content).tbLogin.Focus();
#endif
        }

        private void ContentControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GSystemView.Visibility = Visibility.Hidden;
            AppContext.Logoff();
            ClearViewsContent();

            ShowLoginView();
        }

        private void TileInicio_Click(object sender, RoutedEventArgs e)
        {
            ClearViewsContent();
        }

        private void TileCadastro_Click(object sender, RoutedEventArgs e)
        {
            ClearViewsContent();

            var cadastroOpcView = new CadastroOpcView();
            MCViews.Content = cadastroOpcView;
            MCViews.UpdateLayout();
        }

        private void TileVendas_Click(object sender, RoutedEventArgs e)
        {
            ClearViewsContent();
        }

        private void TileRelat_Click(object sender, RoutedEventArgs e)
        {
            ClearViewsContent();
        }

        private void TileGeral_Click(object sender, RoutedEventArgs e)
        {
            ClearViewsContent();
        }

        private void ClearViewsContent()
        {
            MCViews.Content = null;
            MCViews.UpdateLayout();
            GC.Collect();
        }
        #endregion
    }
}
