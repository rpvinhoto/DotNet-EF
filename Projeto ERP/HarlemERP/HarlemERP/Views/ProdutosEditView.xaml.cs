using HarlemERP;
using HarlemErpDataModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HarlemErpClient.Views
{
    /// <summary>
    /// Interaction logic for ProdutosEditView.xaml
    /// </summary>
    public partial class ProdutosEditView : UserControlEditBase
    {
        #region Fields
        private produtos _produto;
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
            CarregarMarcas();
            CarregarCategorias();
        }

        public override void CarregarEntidade(int id)
        {
            using (var entities = new DataModelEntities())
            {
                _produto = entities.produtos.Where(p => p.id == id).FirstOrDefault();
                tbCodigoProduto.Text = _produto.codigo;
                tbDescricaoProduto.Text = _produto.descricao;
                cbMarcaProduto.SelectedValue = _produto.marca;
                cbCategoriaProduto.SelectedValue = _produto.categoria;
            }
        }

        protected void CarregarMarcas()
        {
            using (var entities = new DataModelEntities())
            {
                var marcas = entities.marcas.OrderBy(o => o.nome);
                cbMarcaProduto.ItemsSource = marcas.ToList();
                cbMarcaProduto.DisplayMemberPath = "nome";
                cbMarcaProduto.SelectedValuePath = "id";
            }
        }

        protected void CarregarCategorias()
        {
            using (var entities = new DataModelEntities())
            {
                var produtosCategoria = entities.produtoscategoria.OrderBy(o => o.descricao);
                cbCategoriaProduto.ItemsSource = produtosCategoria.ToList();
                cbCategoriaProduto.DisplayMemberPath = "descricao";
                cbCategoriaProduto.SelectedValuePath = "id";
            }
        }

        public override async Task<bool> SaveAsync()
        {
            if (await ValidarCampos())
            {
                using (var entities = new DataModelEntities())
                {
                    if (_produto == null)
                    {
                        _produto = new produtos()
                        {
                            codigo = tbCodigoProduto.Text,
                            descricao = tbDescricaoProduto.Text,
                            marca = Int32.Parse(cbMarcaProduto.SelectedValue.ToString()),
                            categoria = Int32.Parse(cbCategoriaProduto.SelectedValue.ToString()),
                            datacadastro = DateTime.Now,
                            usuariocadastro = AppContext.UsuarioLogado.id
                        };
                        entities.produtos.Add(_produto);
                    }
                    else
                    {
                        _produto.codigo = tbCodigoProduto.Text.Trim();
                        _produto.descricao = tbDescricaoProduto.Text.Trim();
                        _produto.marca = Int32.Parse(cbMarcaProduto.SelectedValue.ToString());
                        _produto.categoria = Int32.Parse(cbCategoriaProduto.SelectedValue.ToString());

                        entities.produtos.Attach(_produto);
                        var entry = entities.Entry<produtos>(_produto);
                        entry.State = System.Data.Entity.EntityState.Modified;
                    }

                    entities.SaveChanges();
                }

                await ((MetroWindow)this.Parent).ShowMessageAsync("Operação finalizada",
                    string.Format("Produto {0} cadastrado com sucesso.", tbDescricaoProduto.Text));
            }
            else
                return false;

            return true;
        }

        private async Task<bool> ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbCodigoProduto.Text))
            {
                await((MetroWindow)this.Parent).ShowMessageAsync("Erro", "Código inválido.");
                tbCodigoProduto.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbDescricaoProduto.Text))
            {
                await ((MetroWindow)this.Parent).ShowMessageAsync("Erro", "Descrição inválida.");
                tbDescricaoProduto.Focus();
                return false;
            }
            if (cbMarcaProduto.SelectedValue == null)
            {
                await ((MetroWindow)this.Parent).ShowMessageAsync("Erro", "Marca inválida.");
                cbMarcaProduto.Focus();
                return false;
            }
            if (cbCategoriaProduto.SelectedValue == null)
            {
                await ((MetroWindow)this.Parent).ShowMessageAsync("Erro", "Categoria inválida.");
                cbCategoriaProduto.Focus();
                return false;
            }
            return true;
        }
        #endregion

    }
}
