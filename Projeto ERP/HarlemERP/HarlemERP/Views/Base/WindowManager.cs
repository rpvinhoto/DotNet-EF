using HarlemErpClient.Views;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace HarlemERP.Views.Base
{
    public static class WindowManager
    {
        public static void ShowDialog(UserControlEditBase view, Window owner, string title, int width, int height)
        {
            var window = new MetroWindow()
            {
                Owner = owner,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Title = title,
                Width = width,
                Height = height,
                ResizeMode = System.Windows.ResizeMode.NoResize,
                BorderThickness = new Thickness(1),
                BorderBrush = null
            };
            view.OnFinalize += (o, args) => window.Close();
            window.Content = view;
            window.Closed += (o, args) => window = null;
            window.SetResourceReference(MetroWindow.GlowBrushProperty, "AccentColorBrush");
            window.ShowDialog();
        }
    }
}
