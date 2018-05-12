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
    /// Interaction logic for ClientesEditView.xaml
    /// </summary>
    public partial class ClientesEditView : UserControlEditBase
    {
        #region Fields
        private clientes _cliente;
        #endregion

        #region Events
        private void cbEstado_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbEstado.SelectedValue != null)
                CarregarMunicipios(Int32.Parse(cbEstado.SelectedValue.ToString()));
            else
                cbMunicipio.ItemsSource = null;
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
            if (cbEstado.Items.Count == 0)
                CarregarEstados();
        }

        public override void CarregarEntidade(int id)
        {
            using (var entities = new DataModelEntities())
            {
                _cliente = entities.clientes.Where(p => p.id == id).FirstOrDefault();
                tbNomeCliente.Text = _cliente.nome;
                dpDataNascCliente.SelectedDate = _cliente.datanascimento;
                rbFeminino.IsChecked = _cliente.sexo == "F";
                rbMasculino.IsChecked = _cliente.sexo == "M";
                tbRgCliente.Text = _cliente.rg;
                tbCpfCliente.Text = _cliente.cpf;
                tbEmailCliente.Text = _cliente.email;
                tbTelefoneCliente.Text = _cliente.telefone;
                tbCelularCliente.Text = _cliente.celular;
                tbLogradouroCliente.Text = _cliente.logradouro;
                tbNumeroCliente.Text = _cliente.numero.ToString();
                tbComplementoCliente.Text = _cliente.complemento;
                tbBairroCliente.Text = _cliente.bairro;
                tbCepCliente.Text = _cliente.cep;

                if (_cliente.municipio.HasValue)
                {
                    cbEstado.SelectedValue = SelecionarEstadoPorMunicipio(_cliente.municipio.Value);
                    CarregarMunicipios(Int32.Parse(cbEstado.SelectedValue.ToString()));
                    cbMunicipio.SelectedValue = _cliente.municipio.Value;
                }
            }
        }

        protected void CarregarEstados()
        {
            using (var entities = new DataModelEntities())
            {
                var estados = entities.estados.OrderBy(o => o.sigla);
                cbEstado.ItemsSource = estados.ToList();
                cbEstado.DisplayMemberPath = "sigla";
                cbEstado.SelectedValuePath = "id";
            }
        }

        protected void CarregarMunicipios(int estado)
        {
            using (var entities = new DataModelEntities())
            {
                var municipios = entities.municipios.Where(o => o.estado == estado).OrderBy(o => o.nome);
                cbMunicipio.ItemsSource = municipios.ToList();
                cbMunicipio.DisplayMemberPath = "nome";
                cbMunicipio.SelectedValuePath = "id";
                cbMunicipio.SelectedIndex = 0;
            }
        }

        protected int SelecionarEstadoPorMunicipio(int municipio)
        {
            using (var entities = new DataModelEntities())
            {
                var municipios = entities.municipios.Where(o => o.id == municipio);
                return municipios.First().estado;
            }
        }

        public override async Task<bool> SaveAsync()
        {
            if (!string.IsNullOrWhiteSpace(tbNomeCliente.Text))
            {
                using (var entities = new DataModelEntities())
                {
                    if (_cliente == null)
                    {
                        _cliente = new clientes()
                        {
                            nome = tbNomeCliente.Text.Trim(),
                            sexo = rbMasculino.IsChecked == true ? "M" : "F",
                            rg = tbRgCliente.Text.Trim(),
                            cpf = tbCpfCliente.Text.Trim(),
                            email = tbEmailCliente.Text.Trim(),
                            telefone = tbTelefoneCliente.Text.Trim(),
                            celular = tbCelularCliente.Text.Trim(),
                            logradouro = tbLogradouroCliente.Text.Trim(),
                            complemento = tbComplementoCliente.Text.Trim(),
                            bairro = tbBairroCliente.Text.Trim(),
                            cep = tbCepCliente.Text.Trim(),
                            datacadastro = DateTime.Now,
                            usuariocadastro = AppContext.UsuarioLogado.id
                        };

                        if (dpDataNascCliente.SelectedDate.HasValue)
                            _cliente.datanascimento = dpDataNascCliente.SelectedDate;

                        if (tbNumeroCliente.Text != string.Empty)
                            _cliente.numero = Int32.Parse(tbNumeroCliente.Text.Trim());

                        if (cbMunicipio.SelectedValue != null)
                            _cliente.municipio = Int32.Parse(cbMunicipio.SelectedValue.ToString());

                        entities.clientes.Add(_cliente);
                    }
                    else
                    {
                        if (_cliente.nome.Trim() != tbNomeCliente.Text.Trim())
                            _cliente.nome = tbNomeCliente.Text.Trim();

                        _cliente.sexo = rbMasculino.IsChecked == true ? "M" : "F";

                        if (_cliente.rg.Trim() != tbRgCliente.Text.Trim())
                            _cliente.rg = tbRgCliente.Text.Trim();

                        if (_cliente.cpf.Trim() != tbCpfCliente.Text.Trim())
                            _cliente.cpf = tbCpfCliente.Text.Trim();

                        if (_cliente.email.Trim() != tbEmailCliente.Text.Trim())
                            _cliente.email = tbEmailCliente.Text.Trim();

                        if (_cliente.telefone.Trim() != tbTelefoneCliente.Text.Trim())
                            _cliente.telefone = tbTelefoneCliente.Text.Trim();

                        if (_cliente.celular.Trim() != tbCelularCliente.Text.Trim())
                            _cliente.celular = tbCelularCliente.Text.Trim();

                        if (_cliente.logradouro.Trim() != tbLogradouroCliente.Text.Trim())
                            _cliente.logradouro = tbLogradouroCliente.Text.Trim();

                        if (_cliente.complemento.Trim() != tbComplementoCliente.Text.Trim())
                            _cliente.complemento = tbComplementoCliente.Text.Trim();

                        if (_cliente.bairro.Trim() != tbBairroCliente.Text.Trim())
                            _cliente.bairro = tbBairroCliente.Text.Trim();

                        if (_cliente.cep.Trim() != tbCepCliente.Text.Trim())
                            _cliente.cep = tbCepCliente.Text.Trim();

                        if (dpDataNascCliente.SelectedDate.HasValue)
                            _cliente.datanascimento = dpDataNascCliente.SelectedDate;
                        else
                            _cliente.datanascimento = null;

                        if (tbNumeroCliente.Text != string.Empty)
                            _cliente.numero = Int32.Parse(tbNumeroCliente.Text.Trim());
                        else
                            _cliente.numero = null;

                        if (cbMunicipio.SelectedValue != null)
                            _cliente.municipio = Int32.Parse(cbMunicipio.SelectedValue.ToString());
                        else
                            _cliente.municipio = null;

                        entities.clientes.Attach(_cliente);
                        var entry = entities.Entry<clientes>(_cliente);
                        entry.State = System.Data.Entity.EntityState.Modified;
                    }

                    entities.SaveChanges();
                }

                await ((MetroWindow)this.Parent).ShowMessageAsync("Operação finalizada",
                    string.Format("Cliente {0} cadastrado com sucesso.", tbNomeCliente.Text));
            }
            else
            {
                await ((MetroWindow)this.Parent).ShowMessageAsync("Erro",
                       "O nome do cliente deve ter pelo menos um caracter.");
                return false;
            }

            return true;
        }
        #endregion
    }
}
