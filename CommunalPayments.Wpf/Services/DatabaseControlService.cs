using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunalPayments.Common.DataContext.Sqlite;
using CommunalPayments.Wpf.ViewModels;

namespace CommunalPayments.Wpf.Services
{
    internal static class DatabaseControlService
    {
        private static readonly MainWindowViewModel MainWindow = new ViewModelLocator().MainWindowModel;

        public static SQLiteConnection GetConnection()
        {
            var connection = new ReceiptDb().GetConnection();

            return connection;
        }

        public static void InsertData()
        {
            var storedValues = new List<string>()
            {
                MainWindow.CalculationYear,
                MainWindow.CalculationMonth,
                MainWindow.ConsumptionValueCold,
                MainWindow.ServiceChargesCold,
                MainWindow.ConsumptionValueHotHeatCarrier,
                MainWindow.ConsumptionValueHotHeatEnergy,
                MainWindow.ServiceChargesHotHeatCarrier,
                MainWindow.ServiceChargesHotHeatEnergy,
                MainWindow.ConsumptionValueEnergyDay,
                MainWindow.ConsumptionValueEnergyNight,
                MainWindow.ServiceChargesEnergy,
                MainWindow.ServiceChargesTotal
            };

            var db = new ReceiptDb();

            var result = db.Insert(storedValues);

            MessageBox.Show($"Команда завершилась с результатом - {result}");
        }
    }
}
