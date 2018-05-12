using HarlemERP.Views.Base;
using HarlemErpDataModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HarlemErpClient.Views
{
    /// <summary>
    /// Interaction logic for ProdutosListView.xaml
    /// </summary>
    public partial class ProdutosListView : UserControlListBase
    {
        #region Fields
        private List<produtos> _listProdutos;
        #endregion

        #region Events
        private void MetroDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditarEntidade();
            CarregarEntidades();
        }
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods
        protected override void Initialize()
        {
            InitializeComponent();

            CarregarEntidades();
        }

        public override void CarregarEntidades()
        {
            using (var entities = new DataModelEntities())
            {
                _listProdutos = new List<produtos>(entities.produtos.OrderBy(o => o.codigo).ThenBy(o => o.descricao));
                MetroDataGrid.ItemsSource = _listProdutos;
            }
        }

        private void EditarEntidade()
        {
            if (MetroDataGrid.SelectedIndex != -1)
            {
                var produtosEditView = new ProdutosEditView();
                produtosEditView.CarregarEntidade(((produtos)MetroDataGrid.SelectedItem).id);
                WindowManager.ShowDialog(produtosEditView, Application.Current.MainWindow, "Editar produto", 550, 325);
            }
        }
        #endregion
                
    }
}
