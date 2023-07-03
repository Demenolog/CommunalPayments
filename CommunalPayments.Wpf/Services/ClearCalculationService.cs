using CommunalPayments.Wpf.ViewModels;
using System;

namespace CommunalPayments.Wpf.Services
{
    internal static class ClearCalculationService
    {
        private static readonly MainWindowViewModel MainWindow = new ViewModelLocator().MainWindowModel;

        public static void Clear()
        {
            MainWindow.ConsumptionValueCold = String.Empty;
            MainWindow.ServiceChargesCold = String.Empty;
            MainWindow.ConsumptionValueHotHeatCarrier = String.Empty;
            MainWindow.ConsumptionValueHotHeatEnergy = String.Empty;
            MainWindow.ServiceChargesHotHeatCarrier = String.Empty;
            MainWindow.ServiceChargesHotHeatEnergy = String.Empty;
            MainWindow.ConsumptionValueEnergyGeneral = String.Empty;
            MainWindow.ConsumptionValueEnergyDay = String.Empty;
            MainWindow.ConsumptionValueEnergyNight = String.Empty;
            MainWindow.ServiceChargesEnergy = String.Empty;
            MainWindow.ServiceChargesTotal = String.Empty;
        }
    }
}