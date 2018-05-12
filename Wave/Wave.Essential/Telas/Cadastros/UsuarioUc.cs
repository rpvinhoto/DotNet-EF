using Wave.Domain.Classes;
using Wave.Essential.Telas.UserControlBase;

namespace Wave.Essential.Telas.Cadastros
{
    public partial class UsuarioUc : FormularioBase
    {
        private long? _id;

        public UsuarioUc(long? id)
        {
            InitializeComponent();

            _id = id;

            if (_id.HasValue)
                CarregarUsuario();
        }

        private void CarregarUsuario()
        {
            var usuario = Usuario.Obter(1);

            tbCodigo.Text = usuario.Id.ToString();
            tbEmail.Text = usuario.Email;
            tbLogin.Text = usuario.Login;

            AplicarVisibilidadeCampos(false);
        }

        private void AplicarVisibilidadeCampos(bool visivel)
        {
            lbSenha.Visible = visivel;
            tbSenha.Visible = visivel;

            lbConfirmacaoSenha.Visible = visivel;
            tbConfirmacaoSenha.Visible = visivel;
        }
    }
}