using CommunalPayments.Common.DataContext.Sqlite;
using CommunalPayments.Wpf.ViewModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows;

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

        public static void GetLatestData(string year, string month)
        {
            if (new ReceiptDb().IsPreviousDataExist(year, month))
            {
                var db = new ReceiptDb();

                var result = db.GetPreviousData(year, month);

                if (result != null)
                {
                    MainWindow.InstrumentPreviousValueCold = result[0];
                    MainWindow.InstrumentPreviousValueHot = result[1];
                    MainWindow.InstrumentPreviousValueEnergyDay = result[2];
                    MainWindow.InstrumentPreviousValueEnergyNight = result[3];
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Данных нет");
            }
        }
    }
}