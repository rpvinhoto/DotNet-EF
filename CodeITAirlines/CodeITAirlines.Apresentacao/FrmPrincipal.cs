using CodeItAirlines.Dominio.Entidades;
using CodeItAirlines.Dominio.Enumeradores;
using System;
using System.Windows.Forms;

namespace CodeITAirlines.Apresentacao
{
    public partial class FrmPrincipal : Form
    {
        #region Constantes
        private const string ValueMemberPessoa = "Id";
        private const string DisplayMemberPessoa = "Descricao";
        private const string TransportarParaAeroporto = "Transportar para aeroporto";
        private const string TransportarParaTerminal = "Transportar para terminal";
        #endregion

        private Cenario _cenario;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        #region Eventos dos componentes
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            IniciarCenario();
        }

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender is ListBox lbxOrigem && lbxOrigem.SelectedItem != null)
                    DoDragDrop(sender, DragDropEffects.Move);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBox_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(ListBox)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBoxCarro_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var lbxOrigem = e.Data.GetData(typeof(ListBox)) as ListBox;
                var lbxDestino = sender as ListBox;

                if (lbxOrigem != null && lbxDestino != null && lbxOrigem != lbxDestino)
                {
                    _cenario.EntrarNoCarro((Pessoa)lbxOrigem.SelectedItem);
                    CarregarLocais();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBoxLocal_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var lbxOrigem = e.Data.GetData(typeof(ListBox)) as ListBox;
                var lbxDestino = sender as ListBox;

                if (lbxOrigem != null && lbxDestino != null && lbxOrigem != lbxDestino)
                {
                    _cenario.SairDoCarro((Pessoa)lbxOrigem.SelectedItem);
                    CarregarLocais();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTransportar_Click(object sender, EventArgs e)
        {
            try
            {
                _cenario.Transportar();

                HabilitarControles();
                CarregarLocais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            IniciarCenario();
        }
        #endregion

        #region Métodos privados
        private void IniciarCenario()
        {
            _cenario = new Cenario();
            _cenario.Iniciar();

            DesabilitarControles();
            CarregarLocais();
            HabilitarControles();
        }

        private void CarregarLocais()
        {
            lbxTerminal.DataSource = null;
            lbxTerminal.ValueMember = ValueMemberPessoa;
            lbxTerminal.DisplayMember = DisplayMemberPessoa;
            lbxTerminal.DataSource = _cenario.ObterPersonagensNoTerminal();

            lbxCarro.DataSource = null;
            lbxCarro.ValueMember = ValueMemberPessoa;
            lbxCarro.DisplayMember = DisplayMemberPessoa;
            lbxCarro.DataSource = _cenario.ObterPersonagensNoCarro();

            lbxAviao.DataSource = null;
            lbxAviao.ValueMember = ValueMemberPessoa;
            lbxAviao.DisplayMember = DisplayMemberPessoa;
            lbxAviao.DataSource = _cenario.ObterPersonagensNoAviao();
        }

        private void HabilitarControles()
        {
            if (_cenario.ObterLocalidadeAtualDoCarro() == Locais.Terminal)
            {
                HabilitarControlesComCarroNoTerminal();
                DesabilitarControlesComCarroNoTerminal();
            }
            else
            {
                HabilitarControlesComCarroNoAeroporto();
                DesabilitarControlesComCarroNoAeroporto();
            }
        }

        private void HabilitarControlesComCarroNoTerminal()
        {
            btnTransportar.Text = TransportarParaAeroporto;

            lbxTerminal.MouseDown += ListBox_MouseDown;
            lbxTerminal.DragOver += ListBox_DragOver;
            lbxTerminal.DragDrop += ListBoxLocal_DragDrop;
        }

        private void HabilitarControlesComCarroNoAeroporto()
        {
            btnTransportar.Text = TransportarParaTerminal;

            lbxAviao.MouseDown += ListBox_MouseDown;
            lbxAviao.DragOver += ListBox_DragOver;
            lbxAviao.DragDrop += ListBoxLocal_DragDrop;
        }

        private void DesabilitarControles()
        {
            DesabilitarControlesComCarroNoTerminal();
            DesabilitarControlesComCarroNoAeroporto();
        }

        private void DesabilitarControlesComCarroNoTerminal()
        {
            lbxAviao.MouseDown -= ListBox_MouseDown;
            lbxAviao.DragOver -= ListBox_DragOver;
            lbxAviao.DragDrop -= ListBoxLocal_DragDrop;
        }

        private void DesabilitarControlesComCarroNoAeroporto()
        {
            lbxTerminal.MouseDown -= ListBox_MouseDown;
            lbxTerminal.DragOver -= ListBox_DragOver;
            lbxTerminal.DragDrop -= ListBoxLocal_DragDrop;
        }
        #endregion
    }
}