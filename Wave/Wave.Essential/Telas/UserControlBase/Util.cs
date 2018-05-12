using System.Windows.Forms;

namespace Wave.Essential.Telas.UserControlBase
{
    public class Util
    {
        public static void AbrirUserControl(UserControl uc, string nomeControle, string titulo)
        {
            uc.Dock = DockStyle.Fill;
            uc.Name = nomeControle;

            PrincipalForm.Instance.PainelPrincipal.Controls.Add(uc);
            PrincipalForm.Instance.PainelPrincipal.Controls[nomeControle].BringToFront();
            PrincipalForm.Instance.Titulo = titulo;
            PrincipalForm.InserirRota(nomeControle, titulo);
            PrincipalForm.Instance.Refresh();
        }
    }
}