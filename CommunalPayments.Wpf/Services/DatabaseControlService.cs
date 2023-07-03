using CommunalPayments.Common.DataContext.Sqlite;
using CommunalPayments.Wpf.Infrastructure.Enums;
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
                MainWindow.ConsumptionValueEnergyGeneral,
                MainWindow.ServiceChargesEnergy,
                MainWindow.ServiceChargesTotal
            };

            using (var db = new ReceiptDb())
            {
                var result = db.InsertData(storedValues);

                MessageBox.Show($"Команда завершилась с результатом - {result}");
            }
        }

        public static void GetLatestData(string year, string month)
        {
            if (month == "Январь")
            {
                month = Months.Декабрь.ToString();
                year = (int.Parse(year) - 1).ToString();
            }

            using (var db = new ReceiptDb())
            {
                if (db.IsPreviousDataExist(year, month))
                {
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

        public static void UpdateDataGrid()
        {
            var db = new ReceiptDb();
        }
    }
}