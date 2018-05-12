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
    /// Interaction logic for ProdutosCategoriaEditView.xaml
    /// </summary>
    public partial class ProdutosCategoriaEditView : UserControlEditBase
    {
        #region Fields
        private produtoscategoria _produtoscategoria;
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
                _produtoscategoria = entities.produtoscategoria.Where(p => p.id == id).FirstOrDefault();
                tbDescricaoProdutosCategoria.Text = _produtoscategoria.descricao;
            }
        }

        public override async Task<bool> SaveAsync()
        {
            if (!string.IsNullOrWhiteSpace(tbDescricaoProdutosCategoria.Text))
            {
                using (var entities = new DataModelEntities())
                {
                    if (_produtoscategoria == null)
                    {
                        _produtoscategoria = new produtoscategoria()
                        {
                            descricao = tbDescricaoProdutosCategoria.Text
                        };
                        entities.produtoscategoria.Add(_produtoscategoria);
                    }
                    else if (_produtoscategoria.descricao.Trim() != tbDescricaoProdutosCategoria.Text.Trim())
                    {
                        _produtoscategoria.descricao = tbDescricaoProdutosCategoria.Text.Trim();

                        entities.produtoscategoria.Attach(_produtoscategoria);
                        var entry = entities.Entry<produtoscategoria>(_produtoscategoria);
                        entry.State = System.Data.Entity.EntityState.Modified;
                    }

                    entities.SaveChanges();
                }

                await ((MetroWindow)this.Parent).ShowMessageAsync("Operação finalizada",
                    string.Format("Categoria {0} cadastrada com sucesso.", tbDescricaoProdutosCategoria.Text));
            }
            else
            {
                await ((MetroWindow)this.Parent).ShowMessageAsync("Erro",
                       "A descrição da categoria deve ter pelo menos um caracter.");
                return false;
            }

            return true;
        }
        #endregion
                
    }
}
