using HarlemErpDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HarlemErpClient.Views
{
    /// <summary>
    /// Interaction logic for EstoqueListView.xaml
    /// </summary>
    public partial class EstoqueListView : UserControlListBase
    {
        #region Fields
        private List<estoque> _listEstoque;
        #endregion

        #region Events
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
                MetroDataGrid.ItemsSource = (from e in entities.estoque
                                             join p in entities.produtos on e.produto equals p.id
                                             select new { descricao = p.descricao, qtd = e.qtd }).
                                             OrderBy(o => o.descricao).ThenBy(o => o.qtd).ToList();
            }
        }
        #endregion
    }
}
