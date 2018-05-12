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
    /// Interaction logic for ProdutosCategoriaListView.xaml
    /// </summary>
    public partial class ProdutosCategoriaListView : UserControlListBase
    {
        #region Fields
        private List<produtoscategoria> _listProdutosCategoria;
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
                _listProdutosCategoria = new List<produtoscategoria>(entities.produtoscategoria.OrderBy(o => o.descricao));
                MetroDataGrid.ItemsSource = _listProdutosCategoria;
            }
        }

        private void EditarEntidade()
        {
            if (MetroDataGrid.SelectedIndex != -1)
            {
                var produtosCategoriaEditView = new ProdutosCategoriaEditView();
                produtosCategoriaEditView.CarregarEntidade(((produtoscategoria)MetroDataGrid.SelectedItem).id);
                WindowManager.ShowDialog(produtosCategoriaEditView, Application.Current.MainWindow, "Editar categoria", 550, 325);
            }
        }
        #endregion
    }
}
