using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommunalPayments.Wpf.Services
{
    internal static class UserAlertService
    {
        public static void Information(string information)
        {
            MessageBox.Show(information, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void Error(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
