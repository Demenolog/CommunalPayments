﻿using System;
using CommunalPayments.Common.DataContext.Sqlite;
using CommunalPayments.Common.DataContext.Sqlite.Models;
using CommunalPayments.Wpf.Infrastructure.Enums;
using CommunalPayments.Wpf.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace CommunalPayments.Wpf.Services
{
    internal static class DatabaseControlService
    {
        private static readonly MainWindowViewModel MainWindow = new ViewModelLocator().MainWindowModel;
        private static readonly DataViewWindowViewModel DataViewWindow = new ViewModelLocator().DataViewWindowModel;

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

                if (DataViewWindow != null)
                {
                    UpdateDataGrid();
                }

                MessageBox.Show($"Команда завершилась с результатом - {result}");
            }
        }

        public static void GetPreviousData(string year, string month)
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
            using (var db = new ReceiptDb())
            {
                if (db.IsAnyData())
                {
                    var data = db.GetAllData();

                    var result = data.OrderBy(x => int.Parse(x.CalculationYear))
                        .ThenBy(x => Enum.Parse(typeof(Months), x.CalculationMonth))
                        .ToList();

                    DataViewWindow.Receipts = new ObservableCollection<ReceiptData>(result);
                }
                else
                {
                    DataViewWindow.Receipts = new ObservableCollection<ReceiptData>();
                    MessageBox.Show("Данных нет");
                }
            }
        }

        public static void DeleteData(int deleteNumber)
        {
            using (var db = new ReceiptDb())
            {
                if (db.IsAnyData())
                {
                    if (db.DeleteData(deleteNumber))
                    {
                        UpdateDataGrid();
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
}