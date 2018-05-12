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
    /// Interaction logic for MarcasListView.xaml
    /// </summary>
    public partial class MarcasListView : UserControlListBase
    {
        #region Fields
        private List<marcas> _listMarcas;
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
                _listMarcas = new List<marcas>(entities.marcas.OrderBy(o => o.nome).ThenBy(o => o.datacadastro));
                MetroDataGrid.ItemsSource = _listMarcas;
            }
        }

        private void EditarEntidade()
        {
            if (MetroDataGrid.SelectedIndex != -1)
            {
                var marcasEditView = new MarcasEditView();
                marcasEditView.CarregarEntidade(((marcas)MetroDataGrid.SelectedItem).id);
                WindowManager.ShowDialog(marcasEditView, Application.Current.MainWindow, "Editar marca", 550, 325);
            }
        }
        #endregion
    }
}
