using HarlemERP;
using HarlemErpDataModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HarlemErpClient.Views
{
    /// <summary>
    /// Interaction logic for MarcasEditView.xaml
    /// </summary>
    public partial class MarcasEditView : UserControlEditBase
    {
        #region Fields
        private marcas _marca;
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
        }

        public override void CarregarEntidade(int id)
        {
            using (var entities = new DataModelEntities())
            {
                _marca = entities.marcas.Where(p => p.id == id).FirstOrDefault();
                tbNomeMarca.Text = _marca.nome;
            }
        }

        public override async Task<bool> SaveAsync()
        {
            if (!string.IsNullOrWhiteSpace(tbNomeMarca.Text))
            {
                using (var entities = new DataModelEntities())
                {
                    if (_marca == null)
                    {
                        _marca = new marcas()
                        {
                            nome = tbNomeMarca.Text,
                            datacadastro = DateTime.Now,
                            usuariocadastro = AppContext.UsuarioLogado.id
                        };
                        entities.marcas.Add(_marca);
                    }
                    else if (_marca.nome.Trim() != tbNomeMarca.Text.Trim())
                    {
                        _marca.nome = tbNomeMarca.Text.Trim();

                        entities.marcas.Attach(_marca);
                        var entry = entities.Entry<marcas>(_marca);
                        entry.State = System.Data.Entity.EntityState.Modified;
                    }

                    entities.SaveChanges();
                }

                await ((MetroWindow)this.Parent).ShowMessageAsync("Operação finalizada",
                    string.Format("Marca {0} cadastrada com sucesso.", tbNomeMarca.Text));
            }
            else
            {
                await ((MetroWindow)this.Parent).ShowMessageAsync("Erro",
                       "O nome da marca deve ter pelo menos um caracter.");
                return false;
            }

            return true;
        }
        #endregion
    }
}
