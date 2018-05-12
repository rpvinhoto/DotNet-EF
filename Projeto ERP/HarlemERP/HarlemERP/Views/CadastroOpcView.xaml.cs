using HarlemERP.Views.Base;
using HarlemErpClient.Views;
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
    /// Interaction logic for CadastroOpc.xaml
    /// </summary>
    public partial class CadastroOpcView : UserControl
    {
        #region Fields
        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public CadastroOpcView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void ListaClientes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenNewListView(new ClientesListView());
        }

        private void NovoCliente_Click(object sender, MouseButtonEventArgs e)
        {
            OpenNewEditView(new ClientesEditView(), "Cadastro de clientes", 550, 500);
        }

        private void ListaProdutos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenNewListView(new ProdutosListView());
        }

        private void NovoProduto_Click(object sender, MouseButtonEventArgs e)
        {
            OpenNewEditView(new ProdutosEditView(), "Cadastro de produtos");
        }

        private void ListaCatProdutos_Click(object sender, MouseButtonEventArgs e)
        {
            OpenNewListView(new ProdutosCategoriaListView());
        }

        private void NovaCatProdutos_Click(object sender, MouseButtonEventArgs e)
        {
            OpenNewEditView(new ProdutosCategoriaEditView(), "Cadastro de categoria de produtos");
        }

        private void NovaMarca_Click(object sender, RoutedEventArgs e)
        {
            OpenNewEditView(new MarcasEditView(), "Cadastro de Marcas");
        }

        private void ListaMarcas_Click(object sender, RoutedEventArgs e)
        {
            OpenNewListView(new MarcasListView());
        }

        private void ListaEstoque_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenNewListView(new EstoqueListView());
        }

        private void TileUsuarios_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ClearViewsContent()
        {
            MCViews.Content = null;
            MCViews.UpdateLayout();
            GC.Collect();
        }

        private void SwapViews(Visibility optionsVisibility, Visibility viewsVisibility)
        {
            GOptions.Visibility = optionsVisibility;
            GViews.Visibility = viewsVisibility;
        }

        private void OpenNewEditView(UserControlEditBase view, string titulo, int width = 550, int height = 325)
        {
            WindowManager.ShowDialog(view, Application.Current.MainWindow, titulo, width, height);

            //ClearViewsContent();

            //SwapViews(Visibility.Hidden, Visibility.Visible);

            //view.OnFinalize += (s, ev) =>
            //{
            //    ClearViewsContent();
            //    SwapViews(Visibility.Visible, Visibility.Hidden);
            //};

            //MCViews.Content = view;
            //MCViews.UpdateLayout();
        }

        private void OpenNewListView(UserControlListBase view)
        {
            ClearViewsContent();

            SwapViews(Visibility.Hidden, Visibility.Visible);

            view.OnFinalize += (s, ev) =>
            {
                ClearViewsContent();
                SwapViews(Visibility.Visible, Visibility.Hidden);
            };

            MCViews.Content = view;
            MCViews.UpdateLayout();
        }
        #endregion

    }
}
