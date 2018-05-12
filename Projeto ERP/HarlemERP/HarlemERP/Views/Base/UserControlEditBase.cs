using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HarlemErpClient.Views
{
    public abstract class UserControlEditBase : UserControl
    {
        #region Events
        public event EventHandler OnFinalize;
        #endregion

        #region Constructors
        public UserControlEditBase(int? id = null)
        {
            Initialize();
        }
        #endregion

        #region Abstract Methods
        protected abstract void Initialize();
        public abstract Task<bool> SaveAsync();
        public abstract void CarregarEntidade(int id);
        #endregion

        #region Interface Methods
        protected void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            if (OnFinalize != null)
                OnFinalize(this, new EventArgs());
        }

        protected async void Salvar_Click(object sender, RoutedEventArgs e)
        {
            await DoSave();
        }

        protected async void LastComponent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                await DoSave();
        }
        #endregion

        #region Private Methods
        private async Task DoSave()
        {
            if (await SaveAsync())
                if (OnFinalize != null)
                    OnFinalize(this, new EventArgs());
        }
        #endregion
    }
}
