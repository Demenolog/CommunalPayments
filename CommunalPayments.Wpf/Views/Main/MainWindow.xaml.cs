using CommunalPayments.Wpf.Services;
using System;

namespace CommunalPayments.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        #region Жизненный цикл

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            ChildWindowService.CloseAll();

            base.OnClosed(e);
        }

        #endregion Жизненный цикл
    }
}