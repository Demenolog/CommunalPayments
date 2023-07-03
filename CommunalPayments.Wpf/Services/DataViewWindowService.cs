using CommunalPayments.Wpf.Views;

namespace CommunalPayments.Wpf.Services
{
    internal static class DataViewWindowService
    {
        private static DataViewWindow s_dataViewWindow = null;

        public static bool IsCreated => s_dataViewWindow != null;

        public static DataViewWindow DataViewWindow
        {
            get => s_dataViewWindow;
            set => s_dataViewWindow = value;
        }

        public static void Create()
        {
            if (DataViewWindow != null) return;

            DataViewWindow = new DataViewWindow();
            DataViewWindow.Closed += (o, args) => DataViewWindow = null;
            //DataViewWindow.Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/Icons/Secondary/Gear.ico"));

            ChildWindowService.Add(DataViewWindow);
            DatabaseControlService.UpdateDataGrid();
        }

        public static bool Show()
        {
            if (DataViewWindow != null)
            {
                DataViewWindow.Show();
                DataViewWindow.Focus();
                return true;
            }

            return false;
        }
    }
}