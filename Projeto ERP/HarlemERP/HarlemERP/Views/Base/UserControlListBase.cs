using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HarlemErpClient.Views
{
    public abstract class UserControlListBase : UserControl
    {
        #region Events
        public event EventHandler OnFinalize;
        #endregion

        #region Constructors
        public UserControlListBase(int? id = null)
        {
            Initialize();
        }
        #endregion

        #region Abstract Methods
        protected abstract void Initialize();
        public abstract void CarregarEntidades();
        #endregion

        #region Interface Methods
        protected void Voltar_Click(object sender, RoutedEventArgs e)
        {
            if (OnFinalize != null)
                OnFinalize(this, new EventArgs());
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
