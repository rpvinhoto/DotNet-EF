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
    /// Interaction logic for ClientesListView.xaml
    /// </summary>
    public partial class ClientesListView : UserControlListBase
    {
        #region Fields
        private List<clientes> _listClientes;
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
                _listClientes = new List<clientes>(entities.clientes.OrderBy(o => o.nome).ThenBy(o => o.cpf));
                MetroDataGrid.ItemsSource = _listClientes;
            }
        }

        private void EditarEntidade()
        {
            if (MetroDataGrid.SelectedIndex != -1)
            {
                var clientesEditView = new ClientesEditView();
                clientesEditView.CarregarEntidade(((clientes)MetroDataGrid.SelectedItem).id);
                WindowManager.ShowDialog(clientesEditView, Application.Current.MainWindow, "Editar cliente", 550, 500);
            }
        }
        #endregion
    }
}
